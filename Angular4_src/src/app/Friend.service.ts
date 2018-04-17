import { Injectable } from '@angular/core';
import { Friend } from './Friend';
import { Friends } from './Friend-mock';

import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BaseRequestOptions, RequestOptions, Headers } from '@angular/http';
import { isNull } from 'lodash';

@Injectable()
export class FriendService {

    private __headers: HttpHeaders;
    urlBase:string = "http://127.0.0.1:5000/api/Friend";

    preparaHeaders():void{
        if(isNull(this.__headers))
        {
            let headers = new HttpHeaders();
            headers.append('Access-Control-Allow-Origin','*');
            headers.append('Content-Type','application/javascript;');
            headers.append('Accept','*/*');
            this.__headers = headers;
        } 
    }
    
 
    constructor(
        private http: HttpClient) { }   
        

    getFriends(): Observable<Friend[]> {
        this.preparaHeaders();
         return this.http.get<Friend[]>(this.urlBase,{ headers:this.__headers});          
      }

          
    getFriend(id:number): Observable<Friend> {
        this.preparaHeaders();
        return this.http.get<Friend>(`${this.urlBase}/${id}`,{ headers:this.__headers});  
      }

      getFriendNearMe(id:number): Observable<Friend[]> {

        this.preparaHeaders();
        return this.http.get<Friend[]>(`${this.urlBase}/NEAR/${id}`,{ headers:this.__headers});  

      }
    
}