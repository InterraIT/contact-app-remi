import { Component, OnInit, ViewChild, TemplateRef } from '@angular/core';
import { Contact } from '../contact.model';
import { DataService } from '../data.service';
import { NgbModal, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
import { AddEditUserComponent } from '../add-edit-user/add-edit-user.component';

@Component({
  selector: 'app-contact-list',
  templateUrl: './contact-list.component.html',
  styleUrls: ['./contact-list.component.scss'],
})
export class ContactListComponent implements OnInit {
  contactList: Contact[] = [];
  selectedContact!: Contact;
  modalRef!: NgbModalRef;

  @ViewChild('deleteUserModal') deleteUserModal!: TemplateRef<any>;

  constructor(
    private contactService: DataService,
    private modalService: NgbModal
  ) {}

  ngOnInit(): void {
    this.getContacts();
  }

  getContacts() {
    this.contactService
      .getAllContacts()
      .subscribe((res) => (this.contactList = res));
  }

  openAddEditPopup(contact: Contact | null) {
    const modalRef = this.modalService.open(AddEditUserComponent, {
      size: 'lg',
    });
    modalRef.componentInstance.contact = contact;

    modalRef.componentInstance.onSave.subscribe((updatedContact: Contact) => {
      if (updatedContact.id) {
        this.contactService.updateContact(updatedContact).subscribe((res) => {
          console.log(res);
          this.getContacts();
        });
      } else {
        this.contactService.insertContact(updatedContact).subscribe((res) => {
          console.log(res);
          this.getContacts();
        });
      }
    });
  }

  openDeleteConfirmation(contact: Contact) {
    this.selectedContact = contact;
    this.modalRef = this.modalService.open(this.deleteUserModal);
  }

  closeDeleteConfirmation() {
    this.modalRef.close();
  }

  deleteContact() {
    this.contactService
      .deleteContact(this.selectedContact?.id)
      .subscribe((res) => {
        console.log(res);
        this.getContacts();
      });
    this.closeDeleteConfirmation();
  }
}
