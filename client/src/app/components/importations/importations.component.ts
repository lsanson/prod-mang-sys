import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpEvent, HttpResponse } from '@angular/common/http';
import { ImportationListModel } from 'src/app/models/importation.model';
import { ImportationService } from 'src/app/services/importations.service';
import { ImportationError } from 'src/app/models/error.model';
import { ErrorDialogService } from 'src/app/services/error-dialog.service';


@Component({
  selector: 'app-importations',
  templateUrl: './importations.component.html',
  styleUrls: ['./importations.component.css']
})
export class ImportationsComponent implements OnInit {

  dataSource: ImportationListModel[] = [];
  errorSource: ImportationError[] = [];
  displayedColumns: string[] = ['id', 'deliveryDate', 'productName', 'quantity', 'totalValue', 'details'];
  shortLink: string = "";
  file: File = null;
  loading: boolean = false;

  constructor(
    protected http: HttpClient,
    protected importationService : ImportationService,
    protected errorDialogService: ErrorDialogService
  ) { }

  ngOnInit(): void {
    this.load()
  }

  onChange(files) {
    this.file = files[0];
    if (this.file !== undefined){
        this.onUpload();
        this.file = null;
    }
  }

  

  load() {
    this.importationService.getImportations().subscribe(
      data => {
        if (data !== null)
        {
          this.dataSource = data;
        }
        else {
          this.dataSource = []
        }
      }
    );
  }

  onUpload() {
    this.loading = !this.loading;
    this.importationService.insert(this.file).subscribe(
      (event: any) =>
      {
        if (event === Object)
        {
          console.log("OK");
        }
      },
      (err: HttpErrorResponse) => {
        this.errorSource = err.error;
        this.errorDialogService.openDialog(this.errorSource, err.status)
      }
    );
    this.ngOnInit();
  }
}
