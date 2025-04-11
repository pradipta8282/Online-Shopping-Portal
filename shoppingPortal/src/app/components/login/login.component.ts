import { Component, OnInit} from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit{

  username:any
  password:any
  ngOnInit(): void {
    
  }
  login(){
    if(this.username=='admin' && this.password=='admin123'){
      window.location.assign("admin");
    alert("Login Success")
  }else{
    alert("Login Failed")
  }

}
}
