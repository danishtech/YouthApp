﻿import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from "@angular/router";
import { Observable } from "rxjs/Observable";
import { Injectable } from "@angular/core";
import { HttpErrorResponse } from "@angular/common/http";
import { IBillItems } from "../../models/IBillItems";
import { BillItemHttpService } from "../../http/bill-items/bill-items-service";

@Injectable()
export class BillItemsResolver implements Resolve<IBillItems[]> {

    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): IBillItems[] | Observable<IBillItems[]> | Promise<IBillItems[]> {
        return this.http.list();
    }
    constructor(private http: BillItemHttpService, private router: Router) {

    }
}