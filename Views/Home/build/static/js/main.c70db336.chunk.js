(this.webpackJsonpfrontend=this.webpackJsonpfrontend||[]).push([[0],{13:function(t,e,n){t.exports={Content:"Content_Content__hDgPc"}},21:function(t,e,n){},22:function(t,e,n){},40:function(t,e,n){"use strict";n.r(e);var c=n(0),a=n(2),s=n.n(a),o=n(12),i=n.n(o),r=(n(21),n.p+"static/media/Platypus-logo.9caa0bc8.png"),d=(n(22),n(15)),j=n(13),l=n.n(j),p=n(14),u=n.n(p),h=function(){var t=Object(a.useState)([]),e=Object(d.a)(t,2),n=e[0],s=e[1];return u.a.post("api/User/GetMonth?officeID=1&month=11&year=2020",{}).then((function(t){s(t.data.days),console.log(t.data.days)})),Object(c.jsx)("div",{className:l.a.Content,children:n.map((function(t,e){return Object(c.jsx)("li",{children:t.date},t)}))})};var b=function(){return Object(c.jsxs)("div",{className:"App",children:[Object(c.jsx)("header",{className:"App-header",children:Object(c.jsx)("img",{src:r,className:"App-logo",alt:"logo"})}),Object(c.jsx)(h,{}),Object(c.jsxs)("footer",{children:[Object(c.jsx)("hr",{}),Object(c.jsx)("p",{children:"Om Platypus"}),Object(c.jsx)("p",{children:"Skicka feedback"})]})]})},f=function(t){t&&t instanceof Function&&n.e(3).then(n.bind(null,41)).then((function(e){var n=e.getCLS,c=e.getFID,a=e.getFCP,s=e.getLCP,o=e.getTTFB;n(t),c(t),a(t),s(t),o(t)}))};i.a.render(Object(c.jsx)(s.a.StrictMode,{children:Object(c.jsx)(b,{})}),document.getElementById("root")),f()}},[[40,1,2]]]);
//# sourceMappingURL=main.c70db336.chunk.js.map