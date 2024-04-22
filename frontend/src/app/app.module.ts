import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavComponent } from './componets/nav/nav.component';
import { BodyComponent } from './componets/body/body.component';
import { FotterComponent } from './componets/fotter/fotter.component';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    BodyComponent,
    FotterComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
