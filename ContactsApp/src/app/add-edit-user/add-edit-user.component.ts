import { Component, Input, Output, EventEmitter, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { Contact } from '../contact.model';

@Component({
  selector: 'app-add-edit-user',
  templateUrl: './add-edit-user.component.html',
  styleUrls: ['./add-edit-user.component.scss'],
})
export class AddEditUserComponent implements OnInit {
  @Input() contact!: Contact;
  @Output() onSave = new EventEmitter<Contact>();

  userForm!: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    public activeModal: NgbActiveModal
  ) {}

  ngOnInit(): void {
    this.createForm();
  }

  private createForm() {
    this.userForm = this.formBuilder.group({
      firstName: [this.contact?.firstName, Validators.required],
      lastName: [this.contact?.lastName, Validators.required],
      email: [this.contact?.email, [Validators.required, Validators.email]],
    });
  }

  save() {
    this.userForm.markAllAsTouched();
    if (this.userForm.valid) {
      const updatedContact: Contact = {
        id: this.contact?.id,
        ...this.userForm.value,
      };
      this.onSave.emit(updatedContact);
      this.activeModal.close();
    }
  }
}
