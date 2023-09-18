import { environment } from '../../environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import Subscription from '@app/models/subscription.model';
import { Observable } from 'rxjs';

@Injectable()
export class SubscriptionService {

  constructor(private http: HttpClient) { }
  
  public postSubscriptions(subscription : Subscription[]) : Observable<Subscription>{
    return this.http.post<Subscription>(`${environment.API}/Subscriptions`,subscription)
  }
  public putSubscription(subscription : Subscription[]) : Observable<Subscription>{
    return this.http.put<Subscription>(`${environment.API}/Subscriptions`,subscription)
  }
  public deleteSusbscription(id : number) : Observable<void>{
    return this.http.delete<void>(`${environment.API}/Subscriptions/${id}`)
  }
}
