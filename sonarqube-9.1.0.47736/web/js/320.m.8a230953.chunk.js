(window.webpackJsonp=window.webpackJsonp||[]).push([[320],{1353:function(e,t,n){var i=n(369),a=n(1354);"string"==typeof(a=a.__esModule?a.default:a)&&(a=[[e.i,a,""]]);var o={insert:"head",singleton:!1},r=(i(a,o),a.locals?a.locals:{});e.exports=r},1354:function(e,t,n){(t=n(370)(!1)).push([e.i,'.account-container{width:600px;margin-left:auto;margin-right:auto}.account-header{padding-top:20px;padding-bottom:20px;border-bottom:1px solid #e6e6e6;background-color:#fff}.account-nav{float:right;padding-top:11px}.account-user{float:left}.account-user h1{line-height:60px}.account-user-avatar{margin-right:20px}.account-user-avatar>img{border-radius:60px}.account-user-avatar:empty{display:none}.account-body{padding:40px 0}.account-profile .boxed-group-inner:not(:first-child){border-top:1px solid #e6e6e6}.account-projects-list{margin-left:-20px;margin-right:-20px}.account-projects-list>li{padding:15px 20px}.account-projects-list>li+li{border-top:1px solid #e6e6e6}.account-project-side{float:right;margin-left:10px;text-align:right}.account-project-analysis{line-height:24px;color:#666;font-size:12px}.account-project-card{position:relative;display:block}.account-project-name{display:inline-block;vertical-align:top;max-width:300px;overflow:hidden;text-overflow:ellipsis;white-space:nowrap}.account-project-name>a{border-bottom-color:#d0d0d0;color:#333}.account-project-name>a:hover{border-bottom-color:#cae3f2;color:#4b9fd5}.account-project-quality-gate{display:inline-block;vertical-align:top;line-height:24px;margin-left:8px}.account-project-description{margin-top:6px;line-height:1.5}.account-project-links{margin-top:6px}.account-project-key{margin-top:6px;color:#666;font-size:12px}.my-activity-issues{position:relative;display:flex;justify-content:center;margin-bottom:70px}.my-activity-issues:after{position:absolute;z-index:5;top:-15px;left:50%;width:1px;height:100px;background-color:#e6e6e6;transform:rotate(30deg);content:""}.my-activity-issues>a{display:block;padding:15px 20px;border:none;border-radius:2px;color:#333}.my-activity-issues>a:hover{background-color:#f3f3f3}.my-activity-recent-issues{margin-right:50px;text-align:right}.my-activity-recent-issues .my-activity-issues-note{text-align:left}.my-activity-all-issues{margin-left:50px}.my-activity-issues-number{display:inline-block;vertical-align:middle;line-height:36px;font-size:36px;font-weight:300}.my-activity-issues-note{display:inline-block;vertical-align:middle;padding-left:10px;padding-top:2px;line-height:16px;font-size:12px}.my-activity-projects{width:360px;margin:0 auto;padding:40px 0}.my-activity-projects-header{line-height:24px;margin-bottom:15px;padding:0 10px}.my-activity-projects>ul>li+li{border-top:1px solid #e6e6e6}.my-activity-projects>ul>li>a{display:block;padding:15px 10px;border:none}.my-activity-projects>ul>li>a:hover{background-color:#f3f3f3}.my-activity-projects .level{width:60px}.my-activity-projects .more{margin-top:30px;text-align:center}.notifications-table{margin-top:-16px}.notifications-add-project-no-search-results{padding:8px}.notifications-add-project-search-results li{padding:8px;cursor:pointer}.notifications-add-project-search-results li.active,.notifications-add-project-search-results li:hover{background-color:#f3f3f3}',""]),e.exports=t},1802:function(e,t,n){"use strict";n.r(t),n.d(t,"Account",(function(){return f}));var i=n(366),a=n(393),o=n(419),r=n(396),c=n(441),s=n(361),l=n(6),p=(n(1353),n(373)),u=n(698);function d(){return i.createElement("nav",{className:"account-nav"},i.createElement(u.a,null,i.createElement("li",null,i.createElement(p.a,{activeClassName:"active",to:"/account/"},Object(l.k)("my_account.profile"))),i.createElement("li",null,i.createElement(p.c,{activeClassName:"active",to:"/account/security/"},Object(l.k)("my_account.security"))),i.createElement("li",null,i.createElement(p.c,{activeClassName:"active",to:"/account/notifications"},Object(l.k)("my_account.notifications"))),i.createElement("li",null,i.createElement(p.c,{activeClassName:"active",to:"/account/projects/"},Object(l.k)("my_account.projects")))))}var m=n(447);function g({user:e}){return i.createElement("div",{className:"account-user"},i.createElement("div",{className:"pull-left account-user-avatar",id:"avatar"},i.createElement(m.a,{hash:e.avatar,name:e.name,size:60})),i.createElement("h1",{className:"pull-left",id:"name"},e.name))}class f extends i.PureComponent{componentDidMount(){this.props.currentUser.isLoggedIn||Object(s.default)()}render(){const{currentUser:e,children:t}=this.props;if(!e.isLoggedIn)return null;const n=Object(l.k)("my_account.page");return i.createElement("div",{id:"account-page"},i.createElement(r.a,{suggestions:"account"}),i.createElement(a.a,{defaultTitle:n,defer:!1,titleTemplate:"%s - ".concat(n)}),i.createElement(o.a,{anchor:"account_main"}),i.createElement("header",{className:"account-header"},i.createElement("div",{className:"account-container clearfix"},i.createElement(g,{user:e}),i.createElement(d,null))),t)}}t.default=Object(c.a)(f)},361:function(e,t,n){"use strict";n.r(t),n.d(t,"default",(function(){return a}));var i=n(496);function a(){const e=Object(i.a)(),t=window.location.pathname+window.location.search+window.location.hash;e.replace({pathname:"/sessions/new",query:{return_to:t}})}},396:function(e,t,n){"use strict";n.d(t,"a",(function(){return o}));var i=n(366),a=n(435);function o({suggestions:e}){return i.createElement(a.a.Consumer,null,({addSuggestions:t,removeSuggestions:n})=>i.createElement(r,{addSuggestions:t,removeSuggestions:n,suggestions:e}))}class r extends i.PureComponent{componentDidMount(){this.props.addSuggestions(this.props.suggestions)}componentDidUpdate(e){e.suggestions!==this.props.suggestions&&(this.props.removeSuggestions(this.props.suggestions),this.props.addSuggestions(e.suggestions))}componentWillUnmount(){this.props.removeSuggestions(this.props.suggestions)}render(){return null}}},419:function(e,t,n){"use strict";n.d(t,"a",(function(){return r}));var i=n(366),a=n(6),o=n(476);function r(e){return i.createElement(o.a.Consumer,null,({addA11ySkipLink:t,removeA11ySkipLink:n})=>i.createElement(c,Object.assign({addA11ySkipLink:t,removeA11ySkipLink:n},e)))}class c extends i.PureComponent{constructor(){super(...arguments),this.getLink=()=>{const{anchor:e,label:t=Object(a.k)("skip_to_content"),weight:n}=this.props;return{key:e,label:t,weight:n}}}componentDidMount(){this.props.addA11ySkipLink(this.getLink())}componentWillUnmount(){this.props.removeA11ySkipLink(this.getLink())}render(){const{anchor:e}=this.props;return i.createElement("span",{id:"a11y_target__".concat(e)})}}},698:function(e,t,n){"use strict";n.d(t,"a",(function(){return r}));var i=n(367),a=n(366);n(699);function o(e,t){if(null==e)return{};var n,i,a=function(e,t){if(null==e)return{};var n,i,a={},o=Object.keys(e);for(i=0;i<o.length;i++)n=o[i],t.indexOf(n)>=0||(a[n]=e[n]);return a}(e,t);if(Object.getOwnPropertySymbols){var o=Object.getOwnPropertySymbols(e);for(i=0;i<o.length;i++)n=o[i],t.indexOf(n)>=0||Object.prototype.propertyIsEnumerable.call(e,n)&&(a[n]=e[n])}return a}function r(e){let{children:t,className:n}=e,r=o(e,["children","className"]);return a.createElement("ul",Object.assign({},r,{className:i("navbar-tabs",n)}),t)}},699:function(e,t,n){var i=n(369),a=n(700);"string"==typeof(a=a.__esModule?a.default:a)&&(a=[[e.i,a,""]]);var o={insert:"head",singleton:!1},r=(i(a,o),a.locals?a.locals:{});e.exports=r},700:function(e,t,n){(t=n(370)(!1)).push([e.i,".navbar-tabs{display:flex;align-items:center;clear:left;height:24px;margin-top:8px}.navbar-tabs>li+li{margin-left:20px}.navbar-tabs>li>a{display:block;height:24px;line-height:16px;padding-top:2px;border-bottom:3px solid transparent;box-sizing:border-box;color:#333;transition:none}.navbar-tabs>li>a.active,.navbar-tabs>li>a:focus,.navbar-tabs>li>a:hover{border-bottom-color:#4b9fd5}",""]),e.exports=t}}]);
//# sourceMappingURL=320.m.8a230953.chunk.js.map