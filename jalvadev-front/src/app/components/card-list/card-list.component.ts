import { Component, Input, OnInit } from '@angular/core';
import { NgFor } from '@angular/common';
import { Card } from '../../interfaces/card';

@Component({
  selector: 'app-card-list',
  imports: [NgFor],
  templateUrl: './card-list.component.html',
  styleUrl: './card-list.component.less'
})
export class CardListComponent implements OnInit {

  @Input() cardList!: Card[];


  ngOnInit(): void {
    
  }
}
