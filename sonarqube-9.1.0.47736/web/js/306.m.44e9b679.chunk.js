(window.webpackJsonp=window.webpackJsonp||[]).push([[306],{1772:function(e,t,n){"use strict";n.r(t),n.d(t,"default",(function(){return oe}));var r=n(366),o=n(393),s=n(381),a=n(4);function l(e){return Object(a.d)("/api/webhooks/deliveries",e).catch(s.a)}function i(e){return Object(a.d)("/api/webhooks/delivery",e).catch(s.a)}var c=n(396),u=n(6),d=n(368),h=n(374),m=n(483),p=n(367),b=n(526),f=n(502);function g(e){const{description:t,dirty:n,error:o}=e,s=n&&e.touched&&void 0===o,a=n&&e.touched&&void 0!==o;return r.createElement("div",{className:"modal-validation-field"},e.label,e.children({className:p({"is-invalid":a,"is-valid":s})}),a&&r.createElement(b.a,{className:"little-spacer-top"}),s&&r.createElement(f.a,{className:"little-spacer-top"}),a&&r.createElement("p",{className:"text-danger"},o),t&&r.createElement("div",{className:"modal-field-description"},t))}function k(e,t){if(null==e)return{};var n,r,o=function(e,t){if(null==e)return{};var n,r,o={},s=Object.keys(e);for(r=0;r<s.length;r++)n=s[r],t.indexOf(n)>=0||(o[n]=e[n]);return o}(e,t);if(Object.getOwnPropertySymbols){var s=Object.getOwnPropertySymbols(e);for(r=0;r<s.length;r++)n=s[r],t.indexOf(n)>=0||Object.prototype.propertyIsEnumerable.call(e,n)&&(o[n]=e[n])}return o}function y(e){let{className:t}=e,n=k(e,["className"]);const{description:o,dirty:s,error:a,label:l,touched:i}=n,c=k(n,["description","dirty","error","label","touched"]),u={description:o,dirty:s,error:a,label:l,touched:i};return r.createElement(g,Object.assign({},u),({className:e})=>r.createElement("input",Object.assign({className:p(t,e)},c)))}var v=n(376),E=n(389),O=n(1725);function C(e,t){if(null==e)return{};var n,r,o=function(e,t){if(null==e)return{};var n,r,o={},s=Object.keys(e);for(r=0;r<s.length;r++)n=s[r],t.indexOf(n)>=0||(o[n]=e[n]);return o}(e,t);if(Object.getOwnPropertySymbols){var s=Object.getOwnPropertySymbols(e);for(r=0;r<s.length;r++)n=s[r],t.indexOf(n)>=0||Object.prototype.propertyIsEnumerable.call(e,n)&&(o[n]=e[n])}return o}class w extends r.Component{constructor(){super(...arguments),this.mounted=!1,this.handleSubmit=(e,{setSubmitting:t})=>{const n=this.props.onSubmit(e),r=()=>{this.mounted&&t(!1)};n?n.then(r,r):r()}}componentDidMount(){this.mounted=!0}componentWillUnmount(){this.mounted=!1}render(){return r.createElement(O.a,{initialValues:this.props.initialValues,isInitialValid:this.props.isInitialValid,onSubmit:this.handleSubmit,validate:this.props.validate},e=>{let{handleSubmit:t}=e,n=C(e,["handleSubmit"]);return r.createElement("form",{onSubmit:t},this.props.children(n))})}}class j extends r.PureComponent{constructor(){super(...arguments),this.handleSubmit=e=>this.props.onSubmit(e).then(()=>{this.props.onClose()})}render(){return r.createElement(E.a,{contentLabel:this.props.header,noBackdrop:this.props.noBackdrop,onRequestClose:this.props.onClose,size:this.props.size},r.createElement(w,{initialValues:this.props.initialValues,isInitialValid:this.props.isInitialValid,onSubmit:this.handleSubmit,validate:this.props.validate},e=>r.createElement(r.Fragment,null,r.createElement("header",{className:"modal-head"},r.createElement("h2",null,this.props.header)),r.createElement("div",{className:"modal-body"},this.props.children(e)),r.createElement("footer",{className:"modal-foot"},r.createElement(v.a,{className:"spacer-right",loading:e.isSubmitting}),r.createElement(d.h,{className:this.props.isDestructive?"button-red":void 0,disabled:e.isSubmitting||!e.isValid||!e.dirty},this.props.confirmButtonText),r.createElement(d.g,{disabled:e.isSubmitting,onClick:this.props.onClose},Object(u.k)("cancel"))))))}}var S=n(397),N=n(399);class x extends r.PureComponent{constructor(){super(...arguments),this.handleCancelClick=e=>{e.preventDefault(),e.currentTarget.blur(),this.props.onClose()},this.handleValidate=e=>{const{name:t,secret:n,url:r}=e,o={};return t.trim()||(o.name=Object(u.k)("webhooks.name.required")),r.trim()?r.startsWith("http://")||r.startsWith("https://")?Object(m.isWebUri)(r)||(o.url=Object(u.k)("webhooks.url.bad_format")):o.url=Object(u.k)("webhooks.url.bad_protocol"):o.url=Object(u.k)("webhooks.url.required"),n&&n.length>200&&(o.secret=Object(u.k)("webhooks.secret.bad_format")),o}}render(){const{webhook:e}=this.props,t=!!e,n=t?Object(u.k)("webhooks.update"):Object(u.k)("webhooks.create"),o=t?Object(u.k)("update_verb"):Object(u.k)("create");return r.createElement(j,{confirmButtonText:o,header:n,initialValues:{name:e&&e.name||"",secret:e&&e.secret||"",url:e&&e.url||""},isInitialValid:t,onClose:this.props.onClose,onSubmit:this.props.onDone,size:"small",validate:this.handleValidate},({dirty:e,errors:t,handleBlur:n,handleChange:o,isSubmitting:s,touched:a,values:l})=>r.createElement(r.Fragment,null,r.createElement(N.a,{className:"big-spacer-bottom"}),r.createElement(y,{autoFocus:!0,dirty:e,disabled:s,error:t.name,id:"webhook-name",label:r.createElement("label",{htmlFor:"webhook-name"},Object(u.k)("webhooks.name"),r.createElement(S.a,null)),name:"name",onBlur:n,onChange:o,touched:a.name,type:"text",value:l.name}),r.createElement(y,{description:Object(u.k)("webhooks.url.description"),dirty:e,disabled:s,error:t.url,id:"webhook-url",label:r.createElement("label",{htmlFor:"webhook-url"},Object(u.k)("webhooks.url"),r.createElement(S.a,null)),name:"url",onBlur:n,onChange:o,touched:a.url,type:"text",value:l.url}),r.createElement(y,{description:Object(u.k)("webhooks.secret.description"),dirty:e,disabled:s,error:t.secret,id:"webhook-secret",label:r.createElement("label",{htmlFor:"webhook-secret"},Object(u.k)("webhooks.secret")),name:"secret",onBlur:n,onChange:o,touched:a.secret,type:"password",value:l.secret})))}}class D extends r.PureComponent{constructor(){super(...arguments),this.mounted=!1,this.state={openCreate:!1},this.handleCreateClose=()=>{this.mounted&&this.setState({openCreate:!1})},this.handleCreateOpen=()=>{this.setState({openCreate:!0})},this.renderCreate=()=>this.props.webhooksCount>=10?r.createElement(h.a,{overlay:Object(u.l)("webhooks.maximum_reached",10)},r.createElement(d.a,{className:"js-webhook-create disabled"},Object(u.k)("create"))):r.createElement(r.Fragment,null,r.createElement(d.a,{className:"js-webhook-create",onClick:this.handleCreateOpen},Object(u.k)("create")),this.state.openCreate&&r.createElement(x,{onClose:this.handleCreateClose,onDone:this.props.onCreate}))}componentDidMount(){this.mounted=!0}componentWillUnmount(){this.mounted=!1}render(){return this.props.loading?null:r.createElement("div",{className:"page-actions"},this.renderCreate())}}var P=n(371),M=n(373);function q({children:e,loading:t}){return r.createElement("header",{className:"page-header"},r.createElement("h1",{className:"page-title"},Object(u.k)("webhooks.page")),t&&r.createElement("i",{className:"spinner"}),e,r.createElement("p",{className:"page-description"},r.createElement(P.FormattedMessage,{defaultMessage:Object(u.k)("webhooks.description"),id:"webhooks.description",values:{url:r.createElement(M.c,{to:"/documentation/project-administration/webhooks/"},Object(u.k)("webhooks.documentation_link"))}})))}var _=n(387),L=n.n(_),U=n(437),I=n(391);function V({onClose:e,onSubmit:t,webhook:n}){const o=Object(u.k)("webhooks.delete");return r.createElement(I.a,{header:o,onClose:e,onSubmit:t},({onCloseClick:e,onFormSubmit:t,submitting:s})=>r.createElement("form",{onSubmit:t},r.createElement("header",{className:"modal-head"},r.createElement("h2",null,o)),r.createElement("div",{className:"modal-body"},Object(u.l)("webhooks.delete.confirm",n.name)),r.createElement("footer",{className:"modal-foot"},r.createElement(v.a,{className:"spacer-right",loading:s}),r.createElement(d.h,{className:"button-red",disabled:s},Object(u.k)("delete")),r.createElement(d.g,{disabled:s,onClick:e},Object(u.k)("cancel")))))}var z=n(404),B=n(622),F=n(398),W=n(436),H=n(377);function R({className:e,delivery:t,loading:n,payload:o}){return r.createElement("div",{className:e},r.createElement("p",{className:"spacer-bottom"},Object(u.l)("webhooks.delivery.response_x",t.httpStatus||Object(u.k)("webhooks.delivery.server_unreachable"))),r.createElement("p",{className:"spacer-bottom"},Object(u.l)("webhooks.delivery.duration_x",Object(H.formatMeasure)(t.durationMs,"MILLISEC"))),r.createElement("p",{className:"spacer-bottom"},Object(u.k)("webhooks.delivery.payload")),r.createElement(v.a,{className:"spacer-left spacer-top",loading:n},o&&r.createElement(W.a,{noCopy:!0,snippet:T(o)})))}function T(e){try{return JSON.stringify(JSON.parse(e),void 0,2)}catch(t){return e}}class J extends r.PureComponent{constructor(){super(...arguments),this.mounted=!1,this.state={loading:!1,open:!1},this.fetchPayload=({delivery:e}=this.props)=>(this.setState({loading:!0}),i({deliveryId:e.id}).then(({delivery:e})=>{this.mounted&&this.setState({payload:e.payload,loading:!1})},()=>{this.mounted&&this.setState({loading:!1})})),this.formatPayload=e=>{try{return JSON.stringify(JSON.parse(e),void 0,2)}catch(t){return e}},this.handleClick=()=>{this.state.payload||this.fetchPayload(),this.setState(({open:e})=>({open:!e}))}}componentDidMount(){this.mounted=!0}componentWillUnmount(){this.mounted=!1}render(){const{delivery:e}=this.props,{loading:t,open:n,payload:o}=this.state;return r.createElement(B.a,{onClick:this.handleClick,open:n,renderHeader:()=>e.success?r.createElement(f.a,{className:"pull-right js-success"}):r.createElement(b.a,{className:"pull-right js-error"}),title:r.createElement(F.a,{date:e.at})},r.createElement(R,{className:"big-spacer-left",delivery:e,loading:t,payload:o}))}}class A extends r.PureComponent{constructor(){super(...arguments),this.mounted=!1,this.state={deliveries:[],loading:!0},this.fetchDeliveries=({webhook:e}=this.props)=>{l({webhook:e.key,ps:10}).then(({deliveries:e,paging:t})=>{this.mounted&&this.setState({deliveries:e,loading:!1,paging:t})},this.stopLoading)},this.fetchMoreDeliveries=({webhook:e}=this.props)=>{const{paging:t}=this.state;t&&(this.setState({loading:!0}),l({webhook:e.key,p:t.pageIndex+1,ps:10}).then(({deliveries:e,paging:t})=>{this.mounted&&this.setState(n=>({deliveries:[...n.deliveries,...e],loading:!1,paging:t}))},this.stopLoading))},this.stopLoading=()=>{this.mounted&&this.setState({loading:!1})}}componentDidMount(){this.mounted=!0,this.fetchDeliveries()}componentWillUnmount(){this.mounted=!1}render(){const{webhook:e}=this.props,{deliveries:t,loading:n,paging:o}=this.state,s=Object(u.l)("webhooks.deliveries_for_x",e.name);return r.createElement(E.a,{contentLabel:s,onRequestClose:this.props.onClose},r.createElement("header",{className:"modal-head"},r.createElement("h2",null,s)),r.createElement("div",{className:"modal-body modal-container"},t.map(e=>r.createElement(J,{delivery:e,key:e.id})),r.createElement("div",{className:"text-center"},r.createElement(v.a,{loading:n})),void 0!==o&&r.createElement(z.a,{className:"little-spacer-bottom",count:t.length,loadMore:this.fetchMoreDeliveries,ready:!n,total:o.total})),r.createElement("footer",{className:"modal-foot"},r.createElement(d.g,{className:"js-modal-close",onClick:this.props.onClose},Object(u.k)("close"))))}}function Z(e,t){var n=Object.keys(e);if(Object.getOwnPropertySymbols){var r=Object.getOwnPropertySymbols(e);t&&(r=r.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),n.push.apply(n,r)}return n}function G(e,t,n){return t in e?Object.defineProperty(e,t,{value:n,enumerable:!0,configurable:!0,writable:!0}):e[t]=n,e}class K extends r.PureComponent{constructor(){super(...arguments),this.mounted=!1,this.state={deleting:!1,deliveries:!1,updating:!1},this.handleDelete=()=>this.props.onDelete(this.props.webhook.key),this.handleDeleteClick=()=>{this.setState({deleting:!0})},this.handleDeletingStop=()=>{this.mounted&&this.setState({deleting:!1})},this.handleDeliveriesClick=()=>{this.setState({deliveries:!0})},this.handleDeliveriesStop=()=>{this.setState({deliveries:!1})},this.handleUpdate=e=>this.props.onUpdate(function(e){for(var t=1;t<arguments.length;t++){var n=null!=arguments[t]?arguments[t]:{};t%2?Z(Object(n),!0).forEach((function(t){G(e,t,n[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(n)):Z(Object(n)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(n,t))}))}return e}({},e,{webhook:this.props.webhook.key})),this.handleUpdateClick=()=>{this.setState({updating:!0})},this.handleUpdatingStop=()=>{this.setState({updating:!1})}}componentDidMount(){this.mounted=!0}componentWillUnmount(){this.mounted=!1}render(){const{webhook:e}=this.props;return r.createElement(r.Fragment,null,r.createElement(U.c,{className:"big-spacer-left"},r.createElement(U.b,{className:"js-webhook-update",onClick:this.handleUpdateClick},Object(u.k)("update_verb")),e.latestDelivery&&r.createElement(U.b,{className:"js-webhook-deliveries",onClick:this.handleDeliveriesClick},Object(u.k)("webhooks.deliveries.show")),r.createElement(U.a,null),r.createElement(U.b,{className:"js-webhook-delete",destructive:!0,onClick:this.handleDeleteClick},Object(u.k)("delete"))),this.state.deliveries&&r.createElement(A,{onClose:this.handleDeliveriesStop,webhook:e}),this.state.updating&&r.createElement(x,{onClose:this.handleUpdatingStop,onDone:this.handleUpdate,webhook:e}),this.state.deleting&&r.createElement(V,{onClose:this.handleDeletingStop,onSubmit:this.handleDelete,webhook:e}))}}var Q=n(639);class X extends r.PureComponent{constructor(){super(...arguments),this.mounted=!1,this.state={loading:!0},this.fetchPayload=({delivery:e}=this.props)=>i({deliveryId:e.id}).then(({delivery:e})=>{this.mounted&&this.setState({payload:e.payload,loading:!1})},()=>{this.mounted&&this.setState({loading:!1})}),this.formatPayload=e=>{try{return JSON.stringify(JSON.parse(e),void 0,2)}catch(t){return e}}}componentDidMount(){this.mounted=!0,this.fetchPayload()}componentWillUnmount(){this.mounted=!1}render(){const{delivery:e,webhook:t}=this.props,{loading:n,payload:o}=this.state,s=Object(u.l)("webhooks.latest_delivery_for_x",t.name);return r.createElement(E.a,{contentLabel:s,onRequestClose:this.props.onClose},r.createElement("header",{className:"modal-head"},r.createElement("h2",null,s)),r.createElement(R,{className:"modal-body modal-container",delivery:e,loading:n,payload:o}),r.createElement("footer",{className:"modal-foot"},r.createElement(d.g,{className:"js-modal-close",onClick:this.props.onClose},Object(u.k)("close"))))}}class Y extends r.PureComponent{constructor(){super(...arguments),this.mounted=!1,this.state={modal:!1},this.handleClick=()=>{this.setState({modal:!0})},this.handleModalClose=()=>{this.mounted&&this.setState({modal:!1})}}componentDidMount(){this.mounted=!0}componentWillUnmount(){this.mounted=!1}render(){const{webhook:e}=this.props;if(!e.latestDelivery)return r.createElement("span",null,Object(u.k)("webhooks.last_execution.none"));const{modal:t}=this.state;return r.createElement(r.Fragment,null,e.latestDelivery.success?r.createElement(f.a,{className:"text-text-top"}):r.createElement(b.a,{className:"text-text-top"}),r.createElement("span",{className:"spacer-left display-inline-flex-center"},r.createElement(F.a,{date:e.latestDelivery.at}),r.createElement(d.b,{className:"button-small little-spacer-left",onClick:this.handleClick},r.createElement(Q.a,null))),t&&r.createElement(X,{delivery:e.latestDelivery,onClose:this.handleModalClose,webhook:e}))}}function $({onDelete:e,onUpdate:t,webhook:n}){return r.createElement("tr",null,r.createElement("td",null,n.name),r.createElement("td",null,n.url),r.createElement("td",null,n.secret?Object(u.k)("yes"):Object(u.k)("no")),r.createElement("td",null,r.createElement(Y,{webhook:n})),r.createElement("td",{className:"thin nowrap text-right"},r.createElement(K,{onDelete:e,onUpdate:t,webhook:n})))}class ee extends r.PureComponent{constructor(){super(...arguments),this.renderHeader=()=>r.createElement("thead",null,r.createElement("tr",null,r.createElement("th",null,Object(u.k)("name")),r.createElement("th",null,Object(u.k)("webhooks.url")),r.createElement("th",null,Object(u.k)("webhooks.secret_header")),r.createElement("th",null,Object(u.k)("webhooks.last_execution")),r.createElement("th",null)))}render(){const{webhooks:e}=this.props;return e.length<1?r.createElement("p",null,Object(u.k)("webhooks.no_result")):r.createElement("table",{className:"data zebra"},this.renderHeader(),r.createElement("tbody",null,L()(e,e=>e.name.toLowerCase()).map(e=>r.createElement($,{key:e.key,onDelete:this.props.onDelete,onUpdate:this.props.onUpdate,webhook:e}))))}}function te(e,t){var n=Object.keys(e);if(Object.getOwnPropertySymbols){var r=Object.getOwnPropertySymbols(e);t&&(r=r.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),n.push.apply(n,r)}return n}function ne(e){for(var t=1;t<arguments.length;t++){var n=null!=arguments[t]?arguments[t]:{};t%2?te(Object(n),!0).forEach((function(t){re(e,t,n[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(n)):te(Object(n)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(n,t))}))}return e}function re(e,t,n){return t in e?Object.defineProperty(e,t,{value:n,enumerable:!0,configurable:!0,writable:!0}):e[t]=n,e}class oe extends r.PureComponent{constructor(){super(...arguments),this.mounted=!1,this.state={loading:!0,webhooks:[]},this.fetchWebhooks=()=>{return(e=this.getScopeParams(),Object(a.d)("/api/webhooks/list",e).catch(s.a)).then(({webhooks:e})=>{this.mounted&&this.setState({loading:!1,webhooks:e})},()=>{this.mounted&&this.setState({loading:!1})});var e},this.getScopeParams=({component:e}=this.props)=>({project:e&&e.key}),this.handleCreate=e=>function(e){return Object(a.j)("/api/webhooks/create",e).catch(s.a)}(ne({name:e.name,url:e.url},e.secret&&{secret:e.secret},{},this.getScopeParams())).then(({webhook:e})=>{this.mounted&&this.setState(({webhooks:t})=>({webhooks:[...t,e]}))}),this.handleDelete=e=>{return(t={webhook:e},Object(a.i)("/api/webhooks/delete",t).catch(s.a)).then(()=>{this.mounted&&this.setState(({webhooks:t})=>({webhooks:t.filter(t=>t.key!==e)}))});var t},this.handleUpdate=e=>function(e){return Object(a.i)("/api/webhooks/update",e).catch(s.a)}(ne({webhook:e.webhook,name:e.name,url:e.url},e.secret&&{secret:e.secret})).then(()=>{this.mounted&&this.setState(({webhooks:t})=>({webhooks:t.map(t=>t.key===e.webhook?ne({},t,{name:e.name,secret:e.secret,url:e.url}):t)}))})}componentDidMount(){this.mounted=!0,this.fetchWebhooks()}componentWillUnmount(){this.mounted=!1}render(){const{loading:e,webhooks:t}=this.state;return r.createElement(r.Fragment,null,r.createElement(c.a,{suggestions:"webhooks"}),r.createElement(o.a,{defer:!1,title:Object(u.k)("webhooks.page")}),r.createElement("div",{className:"page page-limited"},r.createElement(q,{loading:e},r.createElement(D,{loading:e,onCreate:this.handleCreate,webhooksCount:t.length})),!e&&r.createElement("div",{className:"boxed-group boxed-group-inner"},r.createElement(ee,{onDelete:this.handleDelete,onUpdate:this.handleUpdate,webhooks:t}))))}}},391:function(e,t,n){"use strict";n.d(t,"a",(function(){return a}));var r=n(366),o=n(389);function s(e,t){if(null==e)return{};var n,r,o=function(e,t){if(null==e)return{};var n,r,o={},s=Object.keys(e);for(r=0;r<s.length;r++)n=s[r],t.indexOf(n)>=0||(o[n]=e[n]);return o}(e,t);if(Object.getOwnPropertySymbols){var s=Object.getOwnPropertySymbols(e);for(r=0;r<s.length;r++)n=s[r],t.indexOf(n)>=0||Object.prototype.propertyIsEnumerable.call(e,n)&&(o[n]=e[n])}return o}class a extends r.Component{constructor(){super(...arguments),this.mounted=!1,this.state={submitting:!1},this.stopSubmitting=()=>{this.mounted&&this.setState({submitting:!1})},this.handleCloseClick=e=>{e&&(e.preventDefault(),e.currentTarget.blur()),this.props.onClose()},this.handleFormSubmit=e=>{e.preventDefault(),this.submit()},this.handleSubmitClick=e=>{e&&(e.preventDefault(),e.currentTarget.blur()),this.submit()},this.submit=()=>{const e=this.props.onSubmit();e&&(this.setState({submitting:!0}),e.then(this.stopSubmitting,this.stopSubmitting))}}componentDidMount(){this.mounted=!0}componentWillUnmount(){this.mounted=!1}render(){const e=this.props,{children:t,header:n,onClose:a,onSubmit:l}=e,i=s(e,["children","header","onClose","onSubmit"]);return r.createElement(o.a,Object.assign({contentLabel:n,onRequestClose:a},i),t({onCloseClick:this.handleCloseClick,onFormSubmit:this.handleFormSubmit,onSubmitClick:this.handleSubmitClick,submitting:this.state.submitting}))}}},392:function(e,t,n){"use strict";n.d(t,"a",(function(){return h})),n.d(t,"b",(function(){return m})),n.d(t,"c",(function(){return p}));var r=n(367),o=n(421),s=n(366),a=n(6),l=n(372);function i(e,t){if(null==e)return{};var n,r,o=function(e,t){if(null==e)return{};var n,r,o={},s=Object.keys(e);for(r=0;r<s.length;r++)n=s[r],t.indexOf(n)>=0||(o[n]=e[n]);return o}(e,t);if(Object.getOwnPropertySymbols){var s=Object.getOwnPropertySymbols(e);for(r=0;r<s.length;r++)n=s[r],t.indexOf(n)>=0||Object.prototype.propertyIsEnumerable.call(e,n)&&(o[n]=e[n])}return o}function c(e){let{fill:t="currentColor"}=e,n=i(e,["fill"]);return s.createElement(l.a,Object.assign({},n),s.createElement("g",{fill:t,fillRule:"nonzero"},s.createElement("path",{d:"M2.931 15.005V3H2v13h9v-.995z"}),s.createElement("path",{d:"M10 4.015h3V14H4V1h6v3.015zM9 8V6H8v2H6v1h2v2h1V9h2V8H9z"}),s.createElement("path",{d:"M11 1v2h2a2.151 2.151 0 0 0-2-2z"})))}var u=n(368),d=n(374);class h extends s.PureComponent{constructor(){super(...arguments),this.mounted=!1,this.state={copySuccess:!1},this.setCopyButton=e=>{this.copyButton=e},this.handleSuccessCopy=()=>{this.mounted&&(this.setState({copySuccess:!0}),setTimeout(()=>{this.mounted&&this.setState({copySuccess:!1})},1e3))}}componentDidMount(){this.mounted=!0,this.copyButton&&(this.clipboard=new o(this.copyButton),this.clipboard.on("success",this.handleSuccessCopy))}componentDidUpdate(){this.clipboard&&this.clipboard.destroy(),this.copyButton&&(this.clipboard=new o(this.copyButton),this.clipboard.on("success",this.handleSuccessCopy))}componentWillUnmount(){this.mounted=!1,this.clipboard&&this.clipboard.destroy()}render(){return this.props.children({setCopyButton:this.setCopyButton,copySuccess:this.state.copySuccess})}}function m({className:e,children:t,copyValue:n}){return s.createElement(h,null,({setCopyButton:o,copySuccess:l})=>s.createElement(d.a,{overlay:Object(a.k)("copied_action"),visible:l},s.createElement(u.a,{className:r("no-select",e),"data-clipboard-text":n,innerRef:o},t||s.createElement(s.Fragment,null,s.createElement(c,{className:"little-spacer-right"}),Object(a.k)("copy")))))}function p(e){const{className:t,copyValue:n}=e;return s.createElement(h,null,({setCopyButton:o,copySuccess:l})=>{var i;return s.createElement(u.b,{"aria-label":null!==(i=e["aria-label"])&&void 0!==i?i:Object(a.k)("copy_to_clipboard"),className:r("no-select",t),"data-clipboard-text":n,innerRef:o,tooltip:Object(a.k)(l?"copied_action":"copy_to_clipboard"),tooltipProps:l?{visible:l}:void 0},s.createElement(c,null))})}},396:function(e,t,n){"use strict";n.d(t,"a",(function(){return s}));var r=n(366),o=n(435);function s({suggestions:e}){return r.createElement(o.a.Consumer,null,({addSuggestions:t,removeSuggestions:n})=>r.createElement(a,{addSuggestions:t,removeSuggestions:n,suggestions:e}))}class a extends r.PureComponent{componentDidMount(){this.props.addSuggestions(this.props.suggestions)}componentDidUpdate(e){e.suggestions!==this.props.suggestions&&(this.props.removeSuggestions(this.props.suggestions),this.props.addSuggestions(e.suggestions))}componentWillUnmount(){this.props.removeSuggestions(this.props.suggestions)}render(){return null}}},397:function(e,t,n){"use strict";n.d(t,"a",(function(){return a}));var r=n(367),o=n(366),s=n(6);function a({className:e}){return o.createElement("em",{"aria-label":Object(s.k)("field_required"),className:r("mandatory little-spacer-left",e)},"*")}},398:function(e,t,n){"use strict";n.d(t,"b",(function(){return a})),n.d(t,"a",(function(){return l}));var r=n(366),o=n(371),s=n(21);const a={year:"numeric",month:"long",day:"numeric",hour:"numeric",minute:"numeric"};function l({children:e,date:t}){return r.createElement(o.FormattedDate,Object.assign({value:Object(s.b)(t)},a),e)}},399:function(e,t,n){"use strict";n.d(t,"a",(function(){return l}));var r=n(367),o=n(366),s=n(371),a=n(6);function l({className:e}){return o.createElement("div",{"aria-hidden":!0,className:r("text-muted",e)},o.createElement(s.FormattedMessage,{id:"fields_marked_with_x_required",defaultMessage:Object(a.k)("fields_marked_with_x_required"),values:{star:o.createElement("em",{className:"mandatory"},"*")}}))}},404:function(e,t,n){"use strict";n.d(t,"a",(function(){return c}));var r=n(367),o=n(366),s=n(6),a=n(377),l=n(376),i=n(368);function c(e){const{className:t,count:n,loading:c,needReload:u,total:d,ready:h=!0}=e,m=d&&d>n;let p;return u&&e.reload?p=o.createElement(i.a,{className:"spacer-left","data-test":"reload",disabled:c,onClick:e.reload},Object(s.k)("reload")):m&&e.loadMore&&(p=o.createElement(i.a,{className:"spacer-left",disabled:c,"data-test":"show-more",onClick:e.loadMore},Object(s.k)("show_more"))),o.createElement("footer",{className:r("spacer-top note text-center",{"new-loading":!h},t)},Object(s.l)("x_of_y_shown",Object(a.formatMeasure)(n,"INT",null),Object(a.formatMeasure)(d,"INT",null)),p,c&&o.createElement(l.a,{className:"text-bottom spacer-left position-absolute"}))}},436:function(e,t,n){"use strict";n.d(t,"a",(function(){return l}));var r=n(367),o=n(366),s=n(392),a=n(452);n(701);function l(e){const{isOneLine:t,noCopy:n,snippet:l}=e,i=o.useRef(null);let c;return c=Array.isArray(l)?l.filter(e=>Object(a.a)(e)).join(t?" ":" \\\n  "):l,o.createElement("div",{className:r("code-snippet spacer-top spacer-bottom display-flex-row",{})},o.createElement("pre",{className:"flex-1",ref:i},c),!n&&o.createElement(s.b,{copyValue:c}))}},437:function(e,t,n){"use strict";n.d(t,"c",(function(){return b})),n.d(t,"b",(function(){return f})),n.d(t,"a",(function(){return g}));var r=n(367),o=n(366),s=n(373),a=n(6),l=n(394),i=n(372);function c(e,t){if(null==e)return{};var n,r,o=function(e,t){if(null==e)return{};var n,r,o={},s=Object.keys(e);for(r=0;r<s.length;r++)n=s[r],t.indexOf(n)>=0||(o[n]=e[n]);return o}(e,t);if(Object.getOwnPropertySymbols){var s=Object.getOwnPropertySymbols(e);for(r=0;r<s.length;r++)n=s[r],t.indexOf(n)>=0||Object.prototype.propertyIsEnumerable.call(e,n)&&(o[n]=e[n])}return o}function u(e){let{fill:t="currentColor",size:n=14}=e,r=c(e,["fill","size"]);return o.createElement(i.a,Object.assign({size:n,viewBox:"0 0 14 14"},r),o.createElement("g",{transform:"matrix(0.0364583,0,0,0.0364583,0,-1.16667)"},o.createElement("path",{d:"M256,224C256,206.333 249.75,191.25 237.25,178.75C224.75,166.25 209.667,160 192,160C174.333,160 159.25,166.25 146.75,178.75C134.25,191.25 128,206.333 128,224C128,241.667 134.25,256.75 146.75,269.25C159.25,281.75 174.333,288 192,288C209.667,288 224.75,281.75 237.25,269.25C249.75,256.75 256,241.667 256,224ZM384,196.75L384,252.25C384,254.25 383.333,256.167 382,258C380.667,259.833 379,260.917 377,261.25L330.75,268.25C327.583,277.25 324.333,284.833 321,291C326.833,299.333 335.75,310.833 347.75,325.5C349.417,327.5 350.25,329.583 350.25,331.75C350.25,333.917 349.5,335.833 348,337.5C343.5,343.667 335.25,352.667 323.25,364.5C311.25,376.333 303.417,382.25 299.75,382.25C297.75,382.25 295.583,381.5 293.25,380L258.75,353C251.417,356.833 243.833,360 236,362.5C233.333,385.167 230.917,400.667 228.75,409C227.583,413.667 224.583,416 219.75,416L164.25,416C161.917,416 159.875,415.292 158.125,413.875C156.375,412.458 155.417,410.667 155.25,408.5L148.25,362.5C140.083,359.833 132.583,356.75 125.75,353.25L90.5,380C88.833,381.5 86.75,382.25 84.25,382.25C81.917,382.25 79.833,381.333 78,379.5C57,360.5 43.25,346.5 36.75,337.5C35.583,335.833 35,333.917 35,331.75C35,329.75 35.667,327.833 37,326C39.5,322.5 43.75,316.958 49.75,309.375C55.75,301.792 60.25,295.917 63.25,291.75C58.75,283.417 55.333,275.167 53,267L7.25,260.25C5.083,259.917 3.333,258.875 2,257.125C0.667,255.375 0,253.417 0,251.25L0,195.75C0,193.75 0.667,191.833 2,190C3.333,188.167 4.917,187.083 6.75,186.75L53.25,179.75C55.583,172.083 58.833,164.417 63,156.75C56.333,147.25 47.417,135.75 36.25,122.25C34.583,120.25 33.75,118.25 33.75,116.25C33.75,114.583 34.5,112.667 36,110.5C40.333,104.5 48.542,95.542 60.625,83.625C72.708,71.708 80.583,65.75 84.25,65.75C86.417,65.75 88.583,66.583 90.75,68.25L125.25,95C132.583,91.167 140.167,88 148,85.5C150.667,62.833 153.083,47.333 155.25,39C156.417,34.333 159.417,32 164.25,32L219.75,32C222.083,32 224.125,32.708 225.875,34.125C227.625,35.542 228.583,37.333 228.75,39.5L235.75,85.5C243.917,88.167 251.417,91.25 258.25,94.75L293.75,68C295.25,66.5 297.25,65.75 299.75,65.75C301.917,65.75 304,66.583 306,68.25C327.5,88.083 341.25,102.25 347.25,110.75C348.417,112.083 349,113.917 349,116.25C349,118.25 348.333,120.167 347,122C344.5,125.5 340.25,131.042 334.25,138.625C328.25,146.208 323.75,152.083 320.75,156.25C325.083,164.583 328.5,172.75 331,180.75L376.75,187.75C378.917,188.083 380.667,189.125 382,190.875C383.333,192.625 384,194.583 384,196.75Z",style:{fill:t}})))}var d=n(368),h=n(392),m=n(383),p=n(374);function b(e){const{children:t,className:n,overlayPlacement:s,small:a,toggleClassName:i}=e;return o.createElement(m.b,{className:n,onOpen:e.onOpen,overlay:o.createElement("ul",{className:"menu"},t),overlayPlacement:s},o.createElement(d.a,{className:r("dropdown-toggle",i,{"button-small":a})},o.createElement(u,{size:a?12:14}),o.createElement(l.a,{className:"little-spacer-left"})))}class f extends o.PureComponent{constructor(){super(...arguments),this.handleClick=e=>{e.preventDefault(),e.currentTarget.blur(),this.props.onClick&&this.props.onClick()}}render(){const e=r(this.props.className,{"text-danger":this.props.destructive});return this.props.download&&"string"==typeof this.props.to?o.createElement("li",null,o.createElement("a",{className:e,download:this.props.download,href:this.props.to,id:this.props.id},this.props.children)):this.props.to?o.createElement("li",null,o.createElement(s.c,{className:e,id:this.props.id,to:this.props.to},this.props.children)):this.props.copyValue?o.createElement(h.a,null,({setCopyButton:t,copySuccess:n})=>o.createElement(p.a,{overlay:Object(a.k)("copied_action"),visible:n},o.createElement("li",{"data-clipboard-text":this.props.copyValue,ref:t},o.createElement("a",{className:e,href:"#",id:this.props.id,onClick:this.handleClick},this.props.children)))):o.createElement("li",null,o.createElement("a",{className:e,href:"#",id:this.props.id,onClick:this.handleClick},this.props.children))}}function g(){return o.createElement("li",{className:"divider"})}},466:function(e,t,n){"use strict";n.d(t,"a",(function(){return a}));var r=n(366),o=n(372);function s(e,t){if(null==e)return{};var n,r,o=function(e,t){if(null==e)return{};var n,r,o={},s=Object.keys(e);for(r=0;r<s.length;r++)n=s[r],t.indexOf(n)>=0||(o[n]=e[n]);return o}(e,t);if(Object.getOwnPropertySymbols){var s=Object.getOwnPropertySymbols(e);for(r=0;r<s.length;r++)n=s[r],t.indexOf(n)>=0||Object.prototype.propertyIsEnumerable.call(e,n)&&(o[n]=e[n])}return o}function a(e){let{fill:t="currentColor"}=e,n=s(e,["fill"]);return r.createElement(o.a,Object.assign({},n),r.createElement("path",{d:"M7.72 11.596L3.119 6.992A.382.382 0 0 1 3 6.713c0-.108.04-.2.118-.279l1.03-1.03a.382.382 0 0 1 .278-.117c.108 0 .201.04.28.117L8 8.7l3.294-3.295a.382.382 0 0 1 .28-.117c.108 0 .2.04.279.117l1.03 1.03a.382.382 0 0 1 .117.28c0 .107-.04.2-.118.278L8.28 11.596a.382.382 0 0 1-.279.117.382.382 0 0 1-.28-.117z",style:{fill:t}}))}},484:function(e,t,n){"use strict";n.d(t,"a",(function(){return l}));var r=n(366),o=n(466),s=n(460);function a(e,t){if(null==e)return{};var n,r,o=function(e,t){if(null==e)return{};var n,r,o={},s=Object.keys(e);for(r=0;r<s.length;r++)n=s[r],t.indexOf(n)>=0||(o[n]=e[n]);return o}(e,t);if(Object.getOwnPropertySymbols){var s=Object.getOwnPropertySymbols(e);for(r=0;r<s.length;r++)n=s[r],t.indexOf(n)>=0||Object.prototype.propertyIsEnumerable.call(e,n)&&(o[n]=e[n])}return o}function l(e){let{open:t}=e,n=a(e,["open"]);return t?r.createElement(o.a,Object.assign({},n)):r.createElement(s.a,Object.assign({},n))}},622:function(e,t,n){"use strict";n.d(t,"a",(function(){return a}));var r=n(367),o=n(366),s=n(484);class a extends o.PureComponent{constructor(){super(...arguments),this.state={hoveringInner:!1},this.handleClick=()=>{this.props.onClick(this.props.data)},this.onDetailEnter=()=>{this.setState({hoveringInner:!0})},this.onDetailLeave=()=>{this.setState({hoveringInner:!1})}}render(){const{className:e,open:t,renderHeader:n,title:a}=this.props;return o.createElement("div",{className:r("boxed-group boxed-group-accordion",e,{"no-hover":this.state.hoveringInner})},o.createElement("div",{className:"boxed-group-header",onClick:this.handleClick,role:"listitem"},o.createElement("span",{className:"boxed-group-accordion-title"},o.createElement(s.a,{className:"little-spacer-right",open:t}),a),n&&n()),t&&o.createElement("div",{className:"boxed-group-inner",onMouseEnter:this.onDetailEnter,onMouseLeave:this.onDetailLeave},this.props.children))}}},639:function(e,t,n){"use strict";n.d(t,"a",(function(){return a}));var r=n(366),o=n(372);function s(e,t){if(null==e)return{};var n,r,o=function(e,t){if(null==e)return{};var n,r,o={},s=Object.keys(e);for(r=0;r<s.length;r++)n=s[r],t.indexOf(n)>=0||(o[n]=e[n]);return o}(e,t);if(Object.getOwnPropertySymbols){var s=Object.getOwnPropertySymbols(e);for(r=0;r<s.length;r++)n=s[r],t.indexOf(n)>=0||Object.prototype.propertyIsEnumerable.call(e,n)&&(o[n]=e[n])}return o}function a(e){let{fill:t="currentColor"}=e,n=s(e,["fill"]);return r.createElement(o.a,Object.assign({},n),r.createElement("path",{d:"M2.968 11.274v1.51q0 0.102-0.075 0.177t-0.177 0.075h-1.51q-0.102 0-0.177-0.075t-0.075-0.177v-1.51q0-0.102 0.075-0.177t0.177-0.075h1.51q0.102 0 0.177 0.075t0.075 0.177zM2.968 8.255v1.51q0 0.102-0.075 0.177t-0.177 0.075h-1.51q-0.102 0-0.177-0.075t-0.075-0.177v-1.51q0-0.102 0.075-0.177t0.177-0.075h1.51q0.102 0 0.177 0.075t0.075 0.177zM2.968 5.235v1.51q0 0.102-0.075 0.177t-0.177 0.075h-1.51q-0.102 0-0.177-0.075t-0.075-0.177v-1.51q0-0.102 0.075-0.177t0.177-0.075h1.51q0.102 0 0.177 0.075t0.075 0.177zM15.045 11.274v1.51q0 0.102-0.075 0.177t-0.177 0.075h-10.568q-0.102 0-0.177-0.075t-0.075-0.177v-1.51q0-0.102 0.075-0.177t0.177-0.075h10.568q0.102 0 0.177 0.075t0.075 0.177zM2.968 2.216v1.51q0 0.102-0.075 0.177t-0.177 0.075h-1.51q-0.102 0-0.177-0.075t-0.075-0.177v-1.51q0-0.102 0.075-0.177t0.177-0.075h1.51q0.102 0 0.177 0.075t0.075 0.177zM15.045 8.255v1.51q0 0.102-0.075 0.177t-0.177 0.075h-10.568q-0.102 0-0.177-0.075t-0.075-0.177v-1.51q0-0.102 0.075-0.177t0.177-0.075h10.568q0.102 0 0.177 0.075t0.075 0.177zM15.045 5.235v1.51q0 0.102-0.075 0.177t-0.177 0.075h-10.568q-0.102 0-0.177-0.075t-0.075-0.177v-1.51q0-0.102 0.075-0.177t0.177-0.075h10.568q0.102 0 0.177 0.075t0.075 0.177zM15.045 2.216v1.51q0 0.102-0.075 0.177t-0.177 0.075h-10.568q-0.102 0-0.177-0.075t-0.075-0.177v-1.51q0-0.102 0.075-0.177t0.177-0.075h10.568q0.102 0 0.177 0.075t0.075 0.177z",style:{fill:t}}))}},701:function(e,t,n){var r=n(369),o=n(702);"string"==typeof(o=o.__esModule?o.default:o)&&(o=[[e.i,o,""]]);var s={insert:"head",singleton:!1},a=(r(o,s),o.locals?o.locals:{});e.exports=a},702:function(e,t,n){(t=n(370)(!1)).push([e.i,".code-snippet{background:#e6e6e6;border-radius:3px}.code-snippet pre{padding:8px 16px;border-right:1px solid hsla(0,0%,78.4%,.5);overflow-y:hidden;overflow-x:auto}.code-snippet>button{height:auto;border:0;border-radius:0;background:transparent;padding:8px}.code-snippet>button:active,.code-snippet>button:focus,.code-snippet>button:hover{background-color:hsla(0,0%,78.4%,.5);color:#236a97}",""]),e.exports=t}}]);
//# sourceMappingURL=306.m.44e9b679.chunk.js.map