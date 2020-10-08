importScripts('https://www.gstatic.com/firebasejs/4.8.1/firebase-app.js');
importScripts('https://www.gstatic.com/firebasejs/4.8.1/firebase-messaging.js');




var config = {
  apiKey: "AIzaSyBaBy4QLK4piPppsX5LYtYX4ZVvFgZ1tA8",
  authDomain: "project125-ff463.firebaseapp.com",
  databaseURL: "https://project125-ff463.firebaseio.com",
  projectId: "project125-ff463",
  storageBucket: "project125-ff463.appspot.com",
  messagingSenderId: "176719391903"
};
firebase.initializeApp(config);

const messaging = firebase.messaging();

// const cacheName = 'hackhathone';
// const staticAssets = [
//     './',
//     './Index.html',
//     './add.html',
//     './chatroom.html',
//     './indexlogin.html',
//     './chat.html',
//     './login.html',
//     './seen.html',
//     './detail.html',
    
//     './css/style.css',
    
// ]

// self.addEventListener('install', function(e) {
//   console.log('[ServiceWorker] Install');
//   e.waitUntil(
//     caches.open(cacheName).then(function(cache) {
//       console.log('[ServiceWorker] Caching app shell');
//       return cache.addAll(staticAssets);
//     })
//   );
// });

// self.addEventListener('fetch', event => {
//     const req = event.request;
//     const url = new URL(req.url);    
//     if (url.origin === location.origin) {
//         event.respondWith(cacheFirst(req))
//     } else {
//         event.respondWith(networkFirst(req))
//     }
// })

// async function cacheFirst(req) {
//     const cacheResponse = await caches.match(req);
//     return cacheResponse || fetch(req);
// }

// async function networkFirst(req) {
//     const cache = await caches.open(cacheName);
//     try {
//         const res = await fetch(req);
//         cache.put(req, res.clone())
//         return res
//     } catch (error) {
//         return await cache.match(req)
//     }
// }



/*
 *
 *  Air Horner
 *  Copyright 2015 Google Inc. All rights reserved.
 *
 *  Licensed under the Apache License, Version 2.0 (the "License");
 *  you may not use this file except in compliance with the License.
 *  You may obtain a copy of the License at
 *
 *      https://www.apache.org/licenses/LICENSE-2.0
 *
 *  Unless required by applicable law or agreed to in writing, software
 *  distributed under the License is distributed on an "AS IS" BASIS,
 *  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *  See the License for the specific language governing permissions and
 *  limitations under the License
 *
 */

const cacheName = `OLX`;
const staticAssets = [
        './Index.html',
            // './add.html',
            // './chatroom.html',
            // './indexlogin.html',
            // './friends.html',
            // './login.html',
           
            // './detail.html',
            
            './css/style.css',
            './css/dcss.css',
            './css/fa/css/font-awesome.min.css',
            './images/footer.png',
            './images/loader.gif',
            './images/olxlogo.png',
            // './js/app.js',
           
            // './js/djs.js',
            //  './js/dslim.js',




           
      ]
      self.addEventListener('install', event => {
        event.waitUntil(
            caches.open(cacheName).then(function(cache) {
              console.log('[ServiceWorker] Caching app shell');
              return cache.addAll(staticAssets);
            })
          );
    })
    self.addEventListener('fetch', event => {
        const req = event.request;
        const url = new URL(req.url);
        if (url.origin === location.origin) {
            event.respondWith(cacheFirst(req))
        } else {
            event.respondWith(networkFirst(req))
        }
    })
    
    async function cacheFirst(req) {
        const cacheResponse = await caches.match(req);
        return cacheResponse || fetch(req);
    }
    
    async function networkFirst(req) {
        const cache = await caches.open(cacheName);
        try {
            const res = await fetch(req);
            cache.put(req, res.clone())
            return res
        } catch (error) {
            return await cache.match(req)
        }
    }