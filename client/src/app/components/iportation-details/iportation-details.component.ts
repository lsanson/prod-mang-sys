import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ImportationDetailsModel } from 'src/app/models/importation.model';
import { ImportationService } from 'src/app/services/importations.service';

@Component({
  selector: 'app-iportation-details',
  templateUrl: './iportation-details.component.html',
  styleUrls: ['./iportation-details.component.css']
})
export class IportationDetailsComponent implements OnInit {
  id?: number;
  dataSource: ImportationDetailsModel[] = [];
  displayedColumns: string[] = ['deliveryDate', 'productName', 'quantity', 'totalValue'];


  constructor(
    private route: ActivatedRoute, 
    protected importationService: ImportationService
  ) { }

  ngOnInit(): void {
    this.id = Number(this.route.snapshot.paramMap.get('id'));
    console.log(this.id);
    this.loadDetails(this.id);
  }

  loadDetails(id) {
    this.importationService.getImportationById(id).subscribe(
      (data) => {
        if (data !== null) {
          this.dataSource = [data];
          console.log(this.dataSource);
        }
      }
    );
  }

}
