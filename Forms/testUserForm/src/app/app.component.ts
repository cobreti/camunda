import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

// declare var CamSDK: any;

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'testUserForm';

  @ViewChild('camundaform', {static: true}) myForm: ElementRef;

  constructor(private activatedRoute : ActivatedRoute) {
    // this.route.params.subscribe(res => console.log(res.id));
  }

  ngOnInit(): void {

    this.activatedRoute.queryParams.subscribe(params => {
      var taskId = params['taskId'];
      if (taskId) {
        console.log(`Task Id ==> ${taskId}`);
        // this.setupCamundaForm(taskId);
      }
    });

    // const url: Observable<Params> = this.activatedRoute.queryParams;
    // url.subscribe( x => console.log(x));
    // console.log(`url : ${this.activatedRoute.url}`);
  }

  setupCamundaForm() {
    // var camClient = new CamSDK.Client({
    //   mock: false,
    //   apiUri: 'http://camunda.danny-thibaudeau.ca/engine-rest'
    // });

    // var taskService = new camClient.resource('task');

    // taskService.form(taskId, function(err, taskFormInfo) {
    //   var url = taskFormInfo.key.replace('embedded:app:', taskFormInfo.contextPath + '/');
    //   var form = new CamSDK.Form(
    //     {
    //       client: camClient,
    //       taskId,
    //       formElement: this.myForm.nativeElement,
    //       done: function(error, camFormInstance) {
    //         console.log('done function called');
    //       }
    //     });
    //   });
  }
}
