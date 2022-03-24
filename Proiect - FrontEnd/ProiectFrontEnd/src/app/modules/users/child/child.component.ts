import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-child',
  templateUrl: './child.component.html',
  styleUrls: ['./child.component.scss']
})
export class ChildComponent implements OnInit {

  @Output() messageFromChild = new EventEmitter<string>();
  @Input() messageFromParent;

  constructor() { }

  ngOnInit(): void {
    console.log(this.messageFromParent);
  }

  public emitData(): void {
    this.messageFromChild.emit('Message from the child component');
  }
}
