import { ChangeDetectorRef, Component } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { ExcelExportService } from "@app/service/excel-export.service";
import {
  UngVienServiceProxy,
  UngVienFullDto,
} from "@shared/service-proxies/service-proxies";
import { MessageService } from "primeng/api";
@Component({
  selector: "app-hosodat",
  templateUrl: "./hosodat.component.html",
  styleUrls: ["./hosodat.component.css"],
})
export class HosodatComponent {
  listUngVien: UngVienFullDto[];
  formLocId: FormGroup;
  formLoccccd: FormGroup;

  constructor(
    private _ungVienService: UngVienServiceProxy,
    private cd: ChangeDetectorRef,
    private fb: FormBuilder,
    private messageService: MessageService,
    private excelExportService: ExcelExportService
  ) {}

  ngOnInit(): void {
    this._ungVienService.getAllUngVien().subscribe((result) => {
      this.listUngVien = result;
    });
    this.formLocId = this.fb.group({
      id: ["", Validators.required],
    });
    this.formLoccccd = this.fb.group({
      cccd: ["", Validators.required],
    });
  }

  reload() {
    this._ungVienService.getAllUngVien().subscribe((result) => {
      this.listUngVien = result;
      this.cd.detectChanges();
    });
  }

  filtercccd() {
    this._ungVienService
      .getUngVienByCMND(this.formLoccccd.value.cccd)
      .subscribe((result) => {
        this.listUngVien = result;
        console.log("loc thanh cong cccd ");
        this.cd.detectChanges();
      });
  }

  // huyphong(phieuDatPhongId: number) {
  //   const confirmDelete = confirm("Bạn có chắc muốn hủy phiếu này?");

  //   if (confirmDelete) {
  //     this._ungVienService
  //       .deleteBookingFromPhieuDaDuyet(phieuDatPhongId)
  //       .subscribe(
  //         (result) => {
  //           this.reload(); // Reload the data after deletion
  //           this.messageService.add({
  //             severity: "success",
  //             summary: "Success",
  //             detail: "Hủy thành công",
  //           });
  //         },
  //         (error) => {
  //           this.messageService.add({
  //             severity: "error",
  //             summary: "Error",
  //             detail: "Hủy không thành công vui lòng kiểm tra lại",
  //           });
  //         }
  //       );
  //   }
  // }

  // dathanhtoan(phieuDatPhongId: number) {
  //   this._ungVienService.finishBooking(phieuDatPhongId).subscribe(
  //     (result) => {
  //       this.reload();
  //       this.messageService.add({
  //         severity: "success",
  //         summary: "Success",
  //         detail: "Thanh toán thành công",
  //       });
  //     },
  //     (error) => {
  //       this.messageService.add({
  //         severity: "error",
  //         summary: "Error",
  //         detail: "Thanh toán không thành công vui lòng kiểm tra lại",
  //       });
  //     }
  //   );
  // }
  exportToExcel() {
    this.excelExportService.exportAsExcelFile(this.listUngVien, "HoSoUngVien");
  }
}
