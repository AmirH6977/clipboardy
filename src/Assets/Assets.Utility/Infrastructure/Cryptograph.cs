﻿using Assets.Model.Common;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Infrastructure;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Infrastructure;
using Microsoft.Owin.Security.OAuth;
using Serilog;
using System;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Assets.Utility.Infrastructure {
    public class Cryptograph {
        #region ctor
        private readonly AppSetting _appSetting;

        public Cryptograph(AppSetting appSetting) {
            _appSetting = appSetting;
        }
        #endregion

        public string Md5(string plainText) {
            if(string.IsNullOrWhiteSpace(plainText))
                return null;
            var md5 = MD5.Create();
            var inputBytes = Encoding.ASCII.GetBytes(plainText);
            var hash = md5.ComputeHash(inputBytes);
            var sb = new StringBuilder();
            foreach(var t in hash) {
                sb.Append(t.ToString("x2"));
            }
            return sb.ToString();
        }

        public string RNG(string password) {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            return Convert.ToBase64String(hashBytes);
        }

        public bool IsEqual(string sentpass, string dbpass) {
            byte[] hashBytes = Convert.FromBase64String(dbpass);

            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);

            var pbkdf2 = new Rfc2898DeriveBytes(sentpass, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            for(int i = 0; i < 20; i++)
                if(hashBytes[i + 16] != hash[i])
                    return false;

            return true;
        }

        public string AesEncrypt(string plainText) {
            try {
                byte[] encrypted;
                using(var aesAlg = Aes.Create()) {
                    var salt = Encoding.ASCII.GetBytes(_appSetting.Encryption.PrivateKey);
                    var key = new Rfc2898DeriveBytes(_appSetting.Encryption.PublicKey, salt);
                    aesAlg.Key = key.GetBytes(aesAlg.KeySize / 8);
                    aesAlg.IV = key.GetBytes(aesAlg.BlockSize / 8);

                    // Create an encryptor to perform the stream transform.
                    var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                    // Create the streams used for encryption.
                    using(var msEncrypt = new MemoryStream()) {
                        using(var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write)) {
                            using(var swEncrypt = new StreamWriter(csEncrypt)) {
                                //Write all data to the stream.
                                swEncrypt.Write(plainText);
                            }
                            encrypted = msEncrypt.ToArray();
                        }
                    }
                }
                return string.Join(",", encrypted);
            }
            catch(Exception ex) {
                Log.Error(ex, $"Error on encrypting.");
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public string AesDecrypt(string cipherText) {
            try {
                string plaintext = null;
                using(var aesAlg = Aes.Create()) {
                    var salt = Encoding.ASCII.GetBytes(_appSetting.Encryption.PrivateKey);
                    var key = new Rfc2898DeriveBytes(_appSetting.Encryption.PublicKey, salt);
                    aesAlg.Key = key.GetBytes(aesAlg.KeySize / 8);
                    aesAlg.IV = key.GetBytes(aesAlg.BlockSize / 8);

                    // Create a decryptor to perform the stream transform.
                    var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                    // Create the streams used for decryption.
                    var cipherBytes = cipherText.Split(',');
                    using(var msDecrypt = new MemoryStream(cipherBytes.Select(s => byte.Parse(s)).ToArray())) {
                        using(var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read)) {
                            using(var srDecrypt = new StreamReader(csDecrypt)) {
                                // Read the decrypted bytes from the decrypting stream
                                // and place them in a string.
                                plaintext = srDecrypt.ReadToEnd();
                            }
                        }
                    }
                }

                return plaintext;
            }
            catch(Exception ex) {
                Log.Error(ex, $"Error on decrypting.");
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public byte[] RijndaelEncrypt(string plainText) {
            byte[] encrypted;
            using(var myRijndael = new RijndaelManaged()) {
                var salt = Encoding.ASCII.GetBytes(_appSetting.Encryption.PrivateKey);
                var key = new Rfc2898DeriveBytes(_appSetting.Encryption.PublicKey, salt);
                myRijndael.Key = key.GetBytes(myRijndael.KeySize / 8);
                myRijndael.IV = key.GetBytes(myRijndael.BlockSize / 8);

                // Encrypt the string to an array of bytes.
                var encryptor = myRijndael.CreateEncryptor(myRijndael.Key, myRijndael.IV);

                // Create the streams used for encryption.
                using(var msEncrypt = new MemoryStream()) {
                    using(var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write)) {
                        using(var swEncrypt = new StreamWriter(csEncrypt)) {

                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            return encrypted;
        }

        public string RijndaelDecrypt(byte[] cipherText) {
            string plaintext = null;
            using(var myRijndael = new RijndaelManaged()) {
                var salt = Encoding.ASCII.GetBytes(_appSetting.Encryption.PrivateKey);
                var key = new Rfc2898DeriveBytes(_appSetting.Encryption.PublicKey, salt);
                myRijndael.Key = key.GetBytes(myRijndael.KeySize / 8);
                myRijndael.IV = key.GetBytes(myRijndael.BlockSize / 8);

                // Decrypt the bytes to a string.
                var decryptor = myRijndael.CreateDecryptor(myRijndael.Key, myRijndael.IV);

                // Create the streams used for decryption.
                using(var msDecrypt = new MemoryStream(cipherText)) {
                    using(var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read)) {
                        using(var srDecrypt = new StreamReader(csDecrypt)) {
                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            return plaintext;
        }

        public string BearerToken(OAuthBearerAuthenticationOptions oabao, Claim[] claims, DateTimeOffset? expiredAt = null) {
            //var test = new OAuthBearerAuthenticationOptions {
            //    AuthenticationMode = AuthenticationMode.Passive,
            //    AuthenticationType = "Bearer"
            //};

            var authticket = new AuthenticationTicket(
                new ClaimsIdentity(claims, "Bearer",
                    "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name",
                    "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"),
                    new AuthenticationProperties {
                        AllowRefresh = true,
                        IsPersistent = true,
                        IssuedUtc = DateTime.UtcNow,
                        ExpiresUtc = expiredAt ?? DateTime.UtcNow.AddDays(7)
                    });

            var token = oabao.AccessTokenFormat.Protect(authticket);
            return token;
        }
    }
}