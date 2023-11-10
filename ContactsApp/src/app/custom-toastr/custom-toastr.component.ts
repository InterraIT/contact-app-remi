import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-custom-toastr',
  templateUrl: './custom-toastr.component.html',
  styleUrls: ['./custom-toastr.component.scss'],
})
export class CustomToastrComponent {
  @Input() toastrData: any;
  @Output() closeAction = new EventEmitter<any>();
  setOpacity: number = 1;
  private toastrTimeout: any;
  constructor() {}

  closeToastr(): void {
    this.toastrTimeout = setTimeout(() => {
      this.closeAction.emit({});
    }, 1000);
  }

  ngOnDestroy(): void {
    clearTimeout(this.toastrTimeout);
  }
}
