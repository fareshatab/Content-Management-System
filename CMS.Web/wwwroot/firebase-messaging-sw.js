importScripts('https://www.gstatic.com/firebasejs/9.1.1/firebase-app-compat.js');
importScripts('https://www.gstatic.com/firebasejs/9.1.1/firebase-messaging-compat.js');

firebase.initializeApp({
    apiKey: "AIzaSyBwLaDK90phbo2aGduEjZBLMJeBnAiL_4I",
    authDomain: "cmsweb-23be2.firebaseapp.com",
    projectId: "cmsweb-23be2",
    storageBucket: "cmsweb-23be2.firebasestorage.app",
    messagingSenderId: "862315757768",
    appId: "1:862315757768:web:845d4c7cc16a97116ea5fd",
    measurementId: "G-7R5YZLRRT8"
});

const messaging = firebase.messaging();

messaging.onBackgroundMessage(function (payload) {
    const title = (payload.notification && payload.notification.title)
        || (payload.data && payload.data.title)
        || 'إشعار جديد';
    const body = (payload.notification && payload.notification.body)
        || (payload.data && payload.data.body)
        || '';

    return self.registration.showNotification(title, { body: body });
});