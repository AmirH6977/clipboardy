﻿
namespace Assets.Model.Base {

    public enum SQLPropType {
        INT,
        VARCHAR,
        NVARCHAR,
        BIT
    }

    public enum Status {
        Inactive = 0,
        Active = 10,
        Pending = 20,
        Deleted = 30
    }

    public enum AccountProfileType {
        Phone = 1,
        Email = 2
    }

    public enum AccountProvider {
        Clipboardy = 1,
        Google = 2,
        Microsoft = 3,
        Facebook = 4,
        Twitter = 5
    }

    public enum ContentType {
        aac = 1,
        tar = 2,
        swf = 3,
        svg = 4,
        sh = 5,
        rtf = 6,
        rar = 7,
        tif = 8,
        pptx = 9,
        php = 10,
        pdf = 11,
        png = 12,
        otf = 13,
        opus = 14,
        ogx = 15,
        ppt = 16,
        tiff = 17,
        ts = 18,
        ttf = 19,
        threegp = 20,
        zip = 21,
        xul = 22,
        xml = 23,
        xlsx = 24,
        xls = 25,
        xhtml = 26,
        woff2 = 27,
        woff = 28,
        webp = 29,
        webm = 30,
        weba = 31,
        wav = 32,
        vsd = 33,
        txt = 34,
        ogv = 35,
        oga = 36,
        odt = 37,
        ods = 38,
        epub = 39,
        eot = 40,
        docx = 41,
        doc = 42,
        csv = 43,
        css = 44,
        csh = 45,
        bz2 = 46,
        bz = 47,
        bmp = 48,
        bin = 49,
        azw = 50,
        avi = 51,
        arc = 52,
        abw = 53,
        gz = 54,
        threeg2 = 55,
        gif = 56,
        html = 57,
        odp = 58,
        mpkg = 59,
        mpeg = 60,
        mp3 = 61,
        mjs = 62,
        midi = 63,
        mid = 64,
        jsonld = 65,
        json = 66,
        js = 67,
        jpeg = 68,
        jpg = 69,
        jar = 70,
        ics = 71,
        ico = 72,
        htm = 73,
        sevenz = 74
    }
}