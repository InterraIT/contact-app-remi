import { Component, EventEmitter, Output } from '@angular/core';
import { NgbModal, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-delete-contact',
  templateUrl: './delete-contact.component.html',
  styleUrls: ['./delete-contact.component.scss'],
})
export class DeleteContactComponent {
  @Output() confirmDeleteEvent = new EventEmitter<boolean>();
  @Output() closeModalEvent = new EventEmitter<boolean>();

  constructor(private modalService: NgbModal) {}

  closeModal() {
    this.closeModalEvent.emit(true);
  }

  confirmDelete() {
    this.confirmDeleteEvent.emit(true);
    this.closeModal();
  }
}
