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
  allQuocGia: QuocGiaFullDto[] = [];
  allTinh: TinhFullDto[] = [];
  allHuyen: HuyenFullDto[] = [];
  allXa: XaFullDto[] = [];
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

    this._quocgiaService.getAllQuocGia().subscribe((result) => {
      this.allQuocGia = result;
      this.suggestionsQuocGia = result;
    });
    this._tinhService.getAllTinh().subscribe((result) => {
      this.allTinh = result;
      this.suggestionsTinh = result;
    });
    this._huyenService.getAllHuyen().subscribe((result) => {
      this.allHuyen = result;
      this.suggestionsHuyen = result;
    });
    this._xaService.getAllXa().subscribe((result) => {
      this.allXa = result;
      this.suggestionsXa = result;
    });
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

  searchDiaDiem(event, field) {
    const query = event.query;
    if (field === "locationsQuocGia") {
      this.suggestionsQuocGia = this.filterQuocgia(query);
    } else if (field === "locationsTinh") {
      this.suggestionsTinh = this.filterTinh(query);
    } else if (field === "locationsHuyen") {
      this.suggestionsHuyen = this.filterHuyen(query);
    } else if (field === "locationsXa") {
      this.suggestionsXa = this.filterXa(query);
    }
  }

  filterQuocgia(query: string): QuocGiaFullDto[] {
    return this.allQuocGia.filter((i) =>
      i.tenQuocGia.toLowerCase().includes(query.toLowerCase())
    );
  }

  filterTinh(query: string): TinhFullDto[] {
    const selectedQuocGia = this.FormThongTinLienHe.value.locationsQuocGia;
    if (selectedQuocGia) {
      this._tinhService
        .getTinhByThanhPho(selectedQuocGia.id)
        .subscribe((result) => {
          this.suggestionsTinh = result.filter((i) =>
            i.tenTinh.toLowerCase().includes(query.toLowerCase())
          );
        });
    } else {
      return this.allTinh.filter((i) =>
        i.tenTinh.toLowerCase().includes(query.toLowerCase())
      );
    }
  }

  filterHuyen(query: string): HuyenFullDto[] {
    const selectedTinh = this.FormThongTinLienHe.value.locationsTinh;
    if (selectedTinh) {
      this._huyenService
        .getHuyenByTinhId(selectedTinh.id)
        .subscribe((result) => {
          this.suggestionsHuyen = result.filter((i) =>
            i.tenHuyen.toLowerCase().includes(query.toLowerCase())
          );
        });
    } else {
      return this.allHuyen.filter((i) =>
        i.tenHuyen.toLowerCase().includes(query.toLowerCase())
      );
    }
  }

  filterXa(query: string): XaFullDto[] {
    const selectedHuyen = this.FormThongTinLienHe.value.locationsHuyen;
    if (selectedHuyen) {
      this._xaService.getXaByHuyenId(selectedHuyen.id).subscribe((result) => {
        this.suggestionsXa = result.filter((i) =>
          i.tenXa.toLowerCase().includes(query.toLowerCase())
        );
      });
    } else {
      return this.allXa.filter((i) =>
        i.tenXa.toLowerCase().includes(query.toLowerCase())
      );
    }
  }
  private markAllAsTouched() {
    this.FormThongTinLienHe.markAllAsTouched();
  }
  onAddHoSo() {
    if (this.FormThongTinLienHe.invalid) {
      this.markAllAsTouched();
      return;
    }
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
          detail: `Đặt không thành công: ${error.message}`,
        });
      }
    );
  }
}
