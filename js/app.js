
 if('serviceWorker' in navigator) {
  navigator.serviceWorker.register('/sw.js', { scope: '/' })
    .then(function(registration) {
          console.log('Service Worker Registered');
    });

  navigator.serviceWorker.ready.then(function(registration) {
     console.log('Service Worker Ready');
  });
}

// Initialize Firebase
var config = {
  apiKey: "AIzaSyBaBy4QLK4piPppsX5LYtYX4ZVvFgZ1tA8",
  authDomain: "project125-ff463.firebaseapp.com",
  databaseURL: "https://project125-ff463.firebaseio.com",
  projectId: "project125-ff463",
  storageBucket: "project125-ff463.appspot.com",
  messagingSenderId: "176719391903"
};
firebase.initializeApp(config);
var storage=firebase.storage();



function logina() {
  document.getElementById("login").style.display = 'block';
  document.getElementById("signup").style.display = "none";

}
function signupa() {
  document.getElementById("signup").style.display = "block";
  document.getElementById("login").style.display = "none";

}
var emailRef = document.getElementById('email');
var passwordRef = document.getElementById('password');
var usernameRef = document.getElementById('username');
var phoneRef = document.getElementById('phone');
var errorRef = document.getElementById('error');
function signup() {
  console.log('signup invoke', emailRef.value, passwordRef.value, usernameRef.value, phoneRef.value);
  firebase.auth().createUserWithEmailAndPassword(emailRef.value, passwordRef.value)
    .then((success) => {
      console.log('signup successfully', success);
      // location = './login.html';
      var uid = success.user.uid;
      var usersdata =
        {

          name: usernameRef.value,
          email: emailRef.value,
          phone: phoneRef.value

        }
      firebase.database().ref("users/" + uid).set(usersdata)
        .then(() => {
          document.getElementById("login").style.display = 'Block';
          document.getElementById("signup").style.display = "none";
        });








    })
    .catch((error) => {
      console.error('something went wrong', error);
      errorRef.innerHTML = error.message;
      alert("user passwor not correct");
    })
}



function login() {
  console.log('login invoke', emailRef.value, passwordRef.value);
  firebase.auth().signInWithEmailAndPassword(emailRef.value, passwordRef.value)
    .then((success) => {
      console.log('signin successfully', success.user);
      alert("signIn SucessFully");
      window.location.hostname;
      //localStorage.setItem('currentUserUid', success.user.uid)
      // location = './polling.html';



    })
    .catch((error) => {
      console.log('something went wrong', error)
    })
}





var globalimg
function pi() {
}

function showDataOnload(a){

  var dataArray = [];
  //firebase.database().ref("adds/select Categories").ref.orderByChild("pdescription").equalTo("asd").on("child_added",(data)=>{






  firebase.database()
  .ref("adds").ref.orderByChild("pcategories").equalTo(a)
  .on("child_added",(data)=>{
   



    var obj = data.val();
    // localforage.setItem("fvtadsdata", obj)
    //     .then(() => {
    //         console.log("Favourite Ads Data has been saved in localforage");
    //     })


    
      console.log("mzkaaaa"+obj);
      for(var key in obj)
      {
        // console.log(data.val(),data.key);
       
        console.log("zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz"+obj[key])
        

       
      }
      dataArray.push(obj);

      var container = document.getElementById('container');
      console.log("xczxcz"+dataArray)
      dataArray.map((v,i)=> {
        var mainref=document.createElement("A")
        mainref.setAttribute("href","detail.html?key="+data.key);
        mainref.setAttribute("class","link");
        container.appendChild(mainref)



        var maindiv=document.createElement("DIV");
        maindiv.setAttribute("style","width: 18rem; Margin:20px; ");
        maindiv.setAttribute("class","card");
        mainref.appendChild(maindiv);


        var image=document.createElement("IMG");
        image.setAttribute("class","card-img-top");
        image.setAttribute("src",v.pimage);
        maindiv.appendChild(image);

        var card_body=document.createElement("DIV");
        card_body.setAttribute("class","card-body");
        maindiv.appendChild(card_body);




        var h1 = document.createElement('H5');
        h1.setAttribute("class","card-title");
        var h1text = document.createTextNode(v.pname)
        h1.appendChild(h1text);
        card_body.appendChild(h1)

        var p=document.createElement("P");
        p.setAttribute("class","card-text")
      // var b=document.createElement("b");
      // var btext=document.createTextNode("this is mzk");
      // b.appendChild(btext);
      // p.appendChild(b);
        var ptext=document.createTextNode(v.pprize);
        p.appendChild(ptext);
      card_body.appendChild(p);




      
      var pp=document.createElement("P");
      pp.setAttribute("class","card-text")
   // pp.setAttribute("style","")
      var ptext=document.createTextNode(v.pdescription);
      pp.appendChild(ptext);
    card_body.appendChild(pp);

    localStorage.setItem("sellerid",v.userid);
      
//message
      // var btn = document.createElement('button')
      // var btnText = document.createTextNode("Chat")
      // btn.appendChild(btnText)
      // btn.setAttribute("class", 'btn btn-info text-right')
      // btn.addEventListener("click", (e) => {
      //     // console.log(v.uid)
      //     var cid = firebase.auth().currentUser.uid;
      //     firebase.database().ref("users/" + cid + "/" + "chatRoom" + '/' +localStorage.getItem("sellerid") + '/').push('Wa-Alaikum-Assalam')
      //         .then(() => {
      //           firebase.database().ref("users/" +localStorage.getItem("sellerid") + "/" + "chatRoom" + '/' + cid + '/').push("Assalam-o-Alaikum")
         
        
      //           alert("done");
      //             setTimeout(() => {
      //                 location = 'chatroom.html'
      //             }, 2000)
      //        })
     // })

//card_body.appendChild(btn);
//end add message

      dataArray =[];

         
      });




  });
  
    //  console.log(dataget.val());
}
function check(){
  if (localStorage.getItem("flag")=="1") {
    
    var parent=document.getElementById("container")   
       parent.innerHTML = "";
       var div = document.createElement("DIV");
       div.innerHTML = `
         <h3 id='b'>No Search Results</h3>
       `;
       parent.appendChild(div);
       alert("asda"); 
     }
}
var flag=true;
function search()
{
  
 // document.getElementById('container').style.display="inline";
  var s=document.getElementById("search").value;

  var matches = [];
  var searchEles = document.getElementById("container").children;
  for(var i = 0; i < searchEles.length; i++) {
      if(searchEles[i].tagName == 'SELECT' || searchEles.tagName == 'INPUT') {
          if(searchEles[i].id.indexOf('q1_') == 0) {
              matches.push(searchEles[i]);
          }
      }
  }

  //window.location.hostname;
  var dataArray = [];
  firebase.database().ref("adds").ref.orderByChild("pname").equalTo(s).on("child_added",(data)=>{

 

 

  
    localStorage.setItem("flag","1")


  // firebase.database()
  // .ref("adds/"+a)
  // .on("child_added",(data)=>{
   
      console.log("mzk"+data);      
      var obj=data.val();
      console.log("mzkaaaa"+obj);
      for(var key in obj)
      {
        // console.log(data.val(),data.key);
       
        console.log("sadasdmzk"+obj[key])
        

       
      }
      dataArray.push(obj);

      var container = document.getElementById('container');
      console.log("xczxcz"+dataArray)
      dataArray.map((v,i)=> {
        var maindiv=document.createElement("DIV");
        maindiv.setAttribute("style","width: 18rem; Margin:20px; ");
        maindiv.setAttribute("class","card");
        container.appendChild(maindiv);


        var image=document.createElement("IMG");
        image.setAttribute("class","card-img-top");
        image.setAttribute("src",v.pimage);
        maindiv.appendChild(image);

        var card_body=document.createElement("DIV");
        card_body.setAttribute("class","card-body");
        maindiv.appendChild(card_body);




        var h1 = document.createElement('H5');
        h1.setAttribute("class","card-title");
        var h1text = document.createTextNode(v.pname)
        h1.appendChild(h1text);
        card_body.appendChild(h1)

        var p=document.createElement("P");
        p.setAttribute("class","card-title")
        var ptext=document.createTextNode(v.pprize);
        p.appendChild(ptext);
      card_body.appendChild(p);



      dataArray =[];
      
      flag =false;
      });




      document.getElementById("b").style.display='none'; 


    }
  
    
  )




if(flag)
{
  var parent=document.getElementById("container")   
  parent.innerHTML = "";
  var div = document.createElement("DIV");

  div.innerHTML = `
    <h3 id='b'>No Search Results</h3>
  `;
parent.appendChild(div)
}
 else
 {
   alert("mil gya he iskoS");
   
   flag=true;
   document.getElementById("b").style.display='none';
  

 }
  

}



function addproduct() {

var imageurl;


  //image kam start
  var file = document.getElementById("pfile").files[0];
  console.log(file);


  //image kam start
var storageRef = storage.ref().child(`product/${file.name}/`);
storageRef.put(file)
.then((snapshot) => {
var pathReference = storage.ref("product/" + file.name).getDownloadURL()

.then((url) => {
  var cid = firebase.auth().currentUser.uid;  

if(cid)
{


  var e = document.getElementById("pcategories");
  var str = e.options[e.selectedIndex].text;
  console.log(str);
    var pname = document.getElementById('pname').value;
  
    var e = document.getElementById("pcategories");
    var pcategories = e.options[e.selectedIndex].text;
  
  
  
    var pprize = document.getElementById("pprize").value;
    var pmodel = document.getElementById("pmodel").value;
    var pdescription = document.getElementById("pdescription").value;
    //var image = globalimg;
 

    console.log("ze"+cid);

  
firebase.database().ref("users/"+cid).on("value",(data)=>
{
  var dataArray=[];
  var d=data.val();
  for(var key in d)
  {
   console.log( d[key]);
  }
  dataArray.push(d);
  dataArray.map((v,i)=> {
    localStorage.setItem("phone",v.phone);
   //console.log(v.phone);

  });


});

var phonee=localStorage.getItem("phone");
console.log("mzk check phone"+phonee)



    var add =
      {
        pname: pname,
        pcategories: pcategories,
        pprize: pprize,
        pmodel: pmodel,
        pdescription: pdescription,
        userid:cid,
        userphone:phonee,
        pimage:url,
        
  
  
  
      };
  
    // console.log(cid);
    firebase.database().ref("adds").push(add)
      .then((added) => {
        console.log("add added",added);
        alert("your add Sucessfully added");
        window.location.href="add.html";
  
      })
      .catch((error) => {
        alert("Something wrong here please contact");
      });
  

    }
    else{
      alert("Please login");
      window.location.href="indexlogin.html";
    }




 })
 .catch((error)=>{
console.log(error.message,'error in url');
alert("please login");
      window.location.href="indexlogin.html";
 });

})
.catch((error) => {
console.log(error.message, 'errorMessage');
      });
//image kam end















 
}


















function getConversation() {
  firebase.auth().onAuthStateChanged(function (user) {
      if (user) {
          var firendsUID = localStorage.getItem("sellerid");
          // console.log(firendsUID, "[friends uid]")
          let usersArray = []
  firebase.database().ref("users/").once("value", (users) => {
              let usersList = users.val()
              // console.log(usersList, "usersList")
              var currentuser = firebase.auth().currentUser.uid;
              // console.log(currentuser)fir
              user = currentuser
              for (var key in usersList) {
                  // console.log(usersList[key])
                  usersList[key].uid = key
                  usersArray.push(usersList[key])

              }
              // console.log(usersArray, 'usersArray')
              var ul = document.getElementById("chatRoom");
              usersArray.map((v, i) => {
                  if (currentuser === v.uid) {
                      currentName = v.name;
                  }
                  if (firendsUID == v.uid) {
                      $("#friendName").html(`Seller Name ${v.name}`)
                      

                      // console.log(v.uid)
                    firebase.database().ref("users/" + v.uid + "/" + "chatRoom" + '/' + currentuser + '/').on('child_added', (CUmessages) => { // current user msgs
                          // console.log(CUmessages, 'cu msgs')
                          localStorage.setItem('CUmsg', JSON.stringify(CUmessages.val()));
                          var userdata = localStorage.getItem('CUmsg');
                          userdata = JSON.parse(userdata);
         
                          var createdLi = crateElement(`${userdata}   (${currentName})`, 'LI', 'list-group-item')
                          // console.log('abcd', createdLi);
                          ul.appendChild(createdLi);
                          // console.log(userdata, 'cu data')
                      })

                      
                  firebase.database().ref("users/" + currentuser + "/" + "chatRoom" + '/' + v.uid + '/').on('child_added', (FUmessages) => {  // friend (user) msgs
                          // console.log(FUmessages, 'fu msgs')
                          localStorage.setItem('FUmsg', JSON.stringify(FUmessages.val()));
                          var userdata = localStorage.getItem('FUmsg');
                          userdata = JSON.parse(userdata);
                          if (currentuser === v.uid) {
                          var createdLi = crateElement(`${userdata}   (${v.name})`, 'LI', 'list-group-item ')
                          }    
                        else
                      {
                        var createdLi = crateElement(`${userdata}   (${v.name})`, 'LI', ' apna')
                      }
                            // console.log('li', createdLi);
                          ul.appendChild(createdLi);
                          // console.log(userdata, 'fu data')

                      })
                      function crateElement(text, element, className) {
                          var li = document.createElement(element);
                          var textNode = document.createTextNode(text);
                          li.appendChild(textNode);
                          li.setAttribute('class', className);
                          return li;
                      }
                  }
              })
          })
      } else {
          console.log('user is not signed in')

      }
  });
}










function sendMsg() {
  var msg = $("#messageBox").val();
  var firendsUID = localStorage.getItem("sellerid");
  let usersArray = []
  firebase.database().ref("users/").once("value", (users) => {
      let usersList = users.val()
      var currentuser = firebase.auth().currentUser.uid;
      for (var key in usersList) {
          usersList[key].uid = key
          usersArray.push(usersList[key])
      }
      usersArray.map((v, i) => {
          if (currentuser === v.uid) {
              currentName = v.name;
          }
          if (firendsUID == v.uid) {

            firebase.database().ref("users/" + v.uid + "/" + "chatRoom" + '/' + currentuser + '/').push(msg)
                  .then(() => {
                      $("#messageBox").val('');
                      console.log(`your this [${msg}] msg has been sent`)
                  })
          }
      })
  })
}


function getAllUrlParams(url,check) {

 
  var url = new URL(url);
  var c = url.searchParams.get(check);
  return c;

}




function jsUcfirst(string) 
{if(string!="undefined")
{
    return string.charAt(0).toUpperCase() + string.slice(1);
}
}




function detail(a)
{
  
  var dataArray = [];
  //firebase.database().ref("adds/select Categories").ref.orderByChild("pdescription").equalTo("asd").on("child_added",(data)=>{

var a=a;





firebase.database().ref().child("adds").child(a).on('value',data=>{
  
   
      console.log("mzk");      
      var obj=data.val();
      console.log("mzkaaaa"+obj);
      for(var key in obj)
      {
        // console.log(data.val(),data.key);
       
        console.log("zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz"+obj[key])
        

       
      }
      dataArray.push(obj);

      var container = document.getElementById('container');
      console.log("xczxcz"+dataArray)
      dataArray.map((v,i)=> {
        document.getElementById("pimage").setAttribute("src",v.pimage)
        document.getElementById("pname").innerHTML=v.pname;
        document.getElementById("pdetail").innerHTML=v.pdescription;
        document.getElementById("price").innerHTML=v.pprize;
        document.getElementById("pmodel").innerHTML=v.pmodel;
        
        firebase.database().ref().child("users").child(v.userid).on('value',data=>{
  
   
          console.log("mzkk");      
          var obj=data.val();
          console.log("mzkaaaa"+obj);
          for(var key in obj)
          {
            // console.log(data.val(),data.key);
           
          }
          dataArray.push(obj);
          console.log("xczxcz"+dataArray)
          dataArray.map((v,i)=> {
            document.getElementById("semail").setAttribute("href",v.email)
            document.getElementById("sname").innerHTML=v.name;
            document.getElementById("sno").innerHTML=v.phone;
            document.getElementById("semail").innerHTML=v.email;
    



          });
        });


  
    localStorage.setItem("sellerid",v.userid);
      
//message
      // var btn = document.createElement('button')
      // var btnText = document.createTextNode("Chat")
      // btn.appendChild(btnText)
      // btn.setAttribute("class", 'btn btn-info text-right')
      // btn.addEventListener("click", (e) => {
      //     // console.log(v.uid)
      //     var cid = firebase.auth().currentUser.uid;
      //     firebase.database().ref("users/" + cid + "/" + "chatRoom" + '/' +localStorage.getItem("sellerid") + '/').push('Wa-Alaikum-Assalam')
      //         .then(() => {
      //           firebase.database().ref("users/" +localStorage.getItem("sellerid") + "/" + "chatRoom" + '/' + cid + '/').push("Assalam-o-Alaikum")
         
        
      //           alert("done");
      //             setTimeout(() => {
      //                 location = 'chatroom.html'
      //             }, 2000)
      //        })
     // })


//end add message

      dataArray =[];

         
      });




  });
  
    //  console.log(dataget.val());

}








function chat()
{
  var cid = firebase.auth().currentUser.uid;
      firebase.database().ref("users/" + cid + "/" + "chatRoom" + '/' +localStorage.getItem("sellerid") + '/').push('Wa-Alaikum-Assalam')
          .then(() => {
            firebase.database().ref("users/" +localStorage.getItem("sellerid") + "/" + "chatRoom" + '/' + cid + '/').push("Assalam-o-Alaikum")
     
    
            alert("done");
              setTimeout(() => {
                  location = 'chatroom.html'
              }, 2000)
         })
        }










