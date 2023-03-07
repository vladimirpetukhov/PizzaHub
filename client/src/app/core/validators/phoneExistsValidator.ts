import { HttpClient, HttpParams } from '@angular/common/http'
import { Injectable } from '@angular/core';
import { AbstractControl, AsyncValidatorFn, ValidationErrors } from '@angular/forms';
import { Observable, of } from 'rxjs';
import { map } from 'rxjs/operators';
import { OrdersService } from 'src/app/orders/orders.service';

@Injectable({ providedIn: 'root' })
export class PhoneExistsValidator {
  constructor(private http: HttpClient) {}

  phoneExistsValidator(): AsyncValidatorFn {
    return (control: AbstractControl): Observable<ValidationErrors | null> => {
      const phone = control.value;

      let params = new HttpParams();
      params = params.set('phone', phone);
      return this.http.get('customer', { params}).pipe(
        map((exists) => {
          if (exists) {
            return { phoneExists: true };
          } else {
            return null;
          }
        })
      );
    };
  }
}
