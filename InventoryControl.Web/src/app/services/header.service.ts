import { Injectable } from '@angular/core';
import { HeaderData } from '../models/header-data.model';
import { BehaviorSubject } from 'rxjs';
import { title } from 'process';

@Injectable({
  providedIn: 'root'
})

export class HeaderService {
  private _headerData = new BehaviorSubject<HeaderData> ({
    title: 'Início',
    icon: 'home',
    routeUrl: ''
  });
  
  constructor() { }

  get headerData(): HeaderData {
    return this._headerData.value
  }

  set headerData(headerData: HeaderData) {
    this._headerData.next(headerData);
  }
}
