import { Component, OnInit } from '@angular/core';
@Component({
  selector: 'page-not-found',
  template: `<body>
<h1> Error 404: Page not Found</h1>
<h4>Please check the url entered</h4>
</body>
`,
  styles: ['body{font-size: 15px}']


})
export class PageNotFoundComponent implements OnInit{
  constructor() { }
  ngOnInit() {

  }

}
