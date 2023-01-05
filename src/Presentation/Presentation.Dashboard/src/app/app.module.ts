import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderCoponent } from './header/header.component';
import { ClipBoardComponent } from './clipBoard/clipBoard.component';
import { ClipBoardListComponent } from './clipBoard/clipBoard-list/clipBoard-list.component';
import { ClipBoardItemComponent } from './clipBoard/clipBoard-list/clipBoard-item/clipBoard-item.component';
import { ColorUsedService } from './help/color-used.service';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    HeaderCoponent,
    ClipBoardComponent,
    ClipBoardListComponent,
    ClipBoardItemComponent,

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FontAwesomeModule,
    FormsModule

  ],
  providers: [ColorUsedService],
  bootstrap: [AppComponent]
})
export class AppModule { }
