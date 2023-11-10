import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ContactListComponent } from './contact-list/contact-list.component';
import { AddEditUserComponent } from './add-edit-user/add-edit-user.component';
import { DeleteContactComponent } from './delete-contact/delete-contact.component';
import { CustomToastrComponent } from './custom-toastr/custom-toastr.component';

@NgModule({
  declarations: [
    AppComponent,
    ContactListComponent,
    AddEditUserComponent,
    DeleteContactComponent,
    CustomToastrComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    NgbModule,
    BrowserAnimationsModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
