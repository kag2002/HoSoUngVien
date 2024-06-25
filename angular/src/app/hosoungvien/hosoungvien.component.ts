import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import {
  HuyenFullDto,
  HuyenServiceProxy,
  QuocGiaFullDto,
  QuocGiaServiceProxy,
  TinhFullDto,
  TinhServiceProxy,
  UngVienDto,
  UngVienFullDto,
  UngVienServiceProxy,
  XaFullDto,
  XaServiceProxy,
} from "@shared/service-proxies/service-proxies";
import { Message, MessageService } from "primeng/api";
import { ExcelExportService } from "../../app/service/excel-export.service";

@Component({
  selector: "app-hosoungvien",
  templateUrl: "./hosoungvien.component.html",
  styleUrls: ["./hosoungvien.component.css"],
})
export class HosoungvienComponent implements OnInit {
  FormThongTinLienHe: FormGroup;
  suggestionsQuocGia: QuocGiaFullDto[];
  suggestionsTinh: TinhFullDto[];
  suggestionsHuyen: HuyenFullDto[];
  suggestionsXa: XaFullDto[];
  thongTinUngVien: UngVienDto = new UngVienDto();

  listUngVien: UngVienFullDto[];
  messages: Message[] | undefined;

  gioitinhs: any[] = [
    { name: "Nam", key: "Nam" },
    { name: "Nữ", key: "Nữ" },
    { name: "Khác", key: "Khác" },
  ];
  constructor(
    private formBuilder: FormBuilder,
    private _quocgiaService: QuocGiaServiceProxy,
    private _tinhService: TinhServiceProxy,
    private _huyenService: HuyenServiceProxy,
    private _xaService: XaServiceProxy,
    private _ungvienService: UngVienServiceProxy,
    private messageService: MessageService
  ) {}

  ngOnInit() {
    this.messages = [
      { severity: "success", detail: "Success Message" },
      { severity: "error", detail: "Error Message" },
    ];
    this.initForm();
  }

  private initForm() {
    this.FormThongTinLienHe = this.formBuilder.group({
      locationsQuocGia: [null, Validators.required],
      locationsTinh: [null, Validators.required],
      locationsHuyen: [null, Validators.required],
      locationsXa: [null, Validators.required],
      name: ["", Validators.required],
      cccd: ["", [Validators.required, Validators.pattern(/^\d{12}$/)]],
      birth: ["", [Validators.required, Validators.pattern(/^\d{4}$/)]],
      gender: [null, Validators.required],
    });
  }

  searchDiaDiem(event) {
    const query = event.query;
    this._quocgiaService.getAllQuocGia().subscribe((result) => {
      this.suggestionsQuocGia = this.filterQuocgia(query, result);
    });
    this._tinhService.getAllTinh().subscribe((result) => {
      this.suggestionsTinh = this.filterTinh(query, result);
    });
    this._huyenService.getAllHuyen().subscribe((result) => {
      this.suggestionsHuyen = this.filterHuyen(query, result);
    });
    this._xaService.getAllXa().subscribe((result) => {
      this.suggestionsXa = this.filterXa(query, result);
    });
  }

  filterQuocgia(query, diaDiem: QuocGiaFullDto[]): any[] {
    const filter: any[] = [];
    for (const i of diaDiem) {
      if (i.tenQuocGia.toLowerCase().indexOf(query.toLowerCase()) === 0) {
        filter.push(i);
      }
    }
    return filter;
  }
  filterTinh(query, diaDiem: TinhFullDto[]): any[] {
    const filter: any[] = [];
    for (const i of diaDiem) {
      if (i.tenTinh.toLowerCase().indexOf(query.toLowerCase()) === 0) {
        filter.push(i);
      }
    }
    return filter;
  }
  filterHuyen(query, diaDiem: HuyenFullDto[]): any[] {
    const filter: any[] = [];
    for (const i of diaDiem) {
      if (i.tenHuyen.toLowerCase().indexOf(query.toLowerCase()) === 0) {
        filter.push(i);
      }
    }
    return filter;
  }
  filterXa(query, diaDiem: XaFullDto[]): any[] {
    const filter: any[] = [];
    for (const i of diaDiem) {
      if (i.tenXa.toLowerCase().indexOf(query.toLowerCase()) === 0) {
        filter.push(i);
      }
    }
    return filter;
  }

  onAddHoSo() {
    debugger;
    this.thongTinUngVien.ten = this.FormThongTinLienHe.value.name;
    this.thongTinUngVien.cmnd = this.FormThongTinLienHe.value.cccd;
    this.thongTinUngVien.gioiTinh = this.FormThongTinLienHe.value.gender.key;
    this.thongTinUngVien.namSinh = this.FormThongTinLienHe.value.birth;
    this.thongTinUngVien.quocGiaId =
      this.FormThongTinLienHe.value.locationsQuocGia.id;
    this.thongTinUngVien.huyenId =
      this.FormThongTinLienHe.value.locationsHuyen.id;
    this.thongTinUngVien.tinhId =
      this.FormThongTinLienHe.value.locationsTinh.id;
    this.thongTinUngVien.xaId = this.FormThongTinLienHe.value.locationsXa.id;
    this._ungvienService.addUngVien(this.thongTinUngVien).subscribe(
      (result) => {
        console.log(this.thongTinUngVien);

        this.messageService.add({
          severity: "success",
          summary: "Success",
          detail: "Đặt thành công",
        });
        console.log("Thêm thành công");
      },
      (error) => {
        console.log(error);
        this.messageService.add({
          severity: "error",
          summary: "Error",
          detail: "Đặt không thành công vui lòng kiểm tra lại",
        });
      }
    );
  }
}
