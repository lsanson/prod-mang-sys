import { Injectable } from '@angular/core'; 
import {HttpClient} from '@angular/common/http'; 
import {Observable} from 'rxjs'; 
import { environment } from 'src/environments/environment';
import { ImportationDetailsModel, ImportationListModel } from '../models/importation.model';
@Injectable({ 
  providedIn: 'root'
}) 

export class ImportationService 
{
    constructor(
        private http: HttpClient
    ) {  }
    
    insert(file):Observable<ImportationListModel[]> { 
  
        // Create form data 
        const formData = new FormData();  
          
        // Store form name as "file" with file data 
        formData.append("file", file, file.name); 
          
        // Make http post request over api 
        // with formData as req 
        return this.http.post<ImportationListModel[]>(`${environment.api_url}importations`, formData) 
    } 

    getImportationById(id: number) : Observable<ImportationDetailsModel> {
        return this.http.get(`${environment.api_url}importations/${id}`);
    }

    getImportations(): Observable<ImportationListModel[]> {
        return this.http.get<ImportationListModel[]>(`${environment.api_url}importations`);
      } 
}