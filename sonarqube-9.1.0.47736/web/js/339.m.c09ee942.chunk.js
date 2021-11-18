(window.webpackJsonp=window.webpackJsonp||[]).push([[339],{1124:function(e,t,n){"use strict";n.r(t),n.d(t,"default",(function(){return K}));var r=n(367),o=n(366),l=n(1042),c=n.n(l),a=n(1060),s=n.n(a),i=n(1063),u=n.n(i),d=n(740),h=n.n(d),p=n(1086),f=n.n(p),m=n(1087),b=n.n(m),g=n(465),O=n(484);class y extends o.PureComponent{constructor(){super(...arguments),this.state={open:!1},this.handleClick=e=>{this.setState(e=>({open:!e.open})),e.stopPropagation(),e.preventDefault()}}renderTitle(e){return o.createElement("a",{"aria-expanded":this.state.open,"aria-haspopup":!0,role:"button",className:"link-no-underline",href:"#",onClick:this.handleClick},o.createElement(O.a,{className:"text-middle little-spacer-right",open:this.state.open}),e.props?e.props.children:e)}render(){const e=o.Children.toArray(this.props.children);if(e.length<1)return null;const t=o.Children.toArray(e[0].props.children);return t.length<2?null:o.createElement("div",{className:"collapse-container"},this.renderTitle(t[0]),this.state.open&&t.slice(1))}}var k=n(0);function v(e,t){if(null==e)return{};var n,r,o=function(e,t){if(null==e)return{};var n,r,o={},l=Object.keys(e);for(r=0;r<l.length;r++)n=l[r],t.indexOf(n)>=0||(o[n]=e[n]);return o}(e,t);if(Object.getOwnPropertySymbols){var l=Object.getOwnPropertySymbols(e);for(r=0;r<l.length;r++)n=l[r],t.indexOf(n)>=0||Object.prototype.propertyIsEnumerable.call(e,n)&&(o[n]=e[n])}return o}function w(e){const{alt:t,src:n}=e,r=v(e,["alt","src"]);return o.createElement("img",Object.assign({alt:t,className:"max-width-100",src:Object(k.getBaseUrl)()+"/images/embed-doc"+n},r))}var E=n(373),j=n(429),x=n(464);function C(e,t){if(null==e)return{};var n,r,o=function(e,t){if(null==e)return{};var n,r,o={},l=Object.keys(e);for(r=0;r<l.length;r++)n=l[r],t.indexOf(n)>=0||(o[n]=e[n]);return o}(e,t);if(Object.getOwnPropertySymbols){var l=Object.getOwnPropertySymbols(e);for(r=0;r<l.length;r++)n=l[r],t.indexOf(n)>=0||Object.prototype.propertyIsEnumerable.call(e,n)&&(o[n]=e[n])}return o}class S extends o.PureComponent{constructor(){super(...arguments),this.handleClickOnAnchor=e=>{const{customProps:t,href:n="#"}=this.props;t&&t.onAnchorClick&&t.onAnchorClick(n,e)}}render(){const e=this.props,{appState:t,children:n,href:r,customProps:l}=e,c=C(e,["appState","children","href","customProps"]);if(r&&r.startsWith("#"))return o.createElement("a",{href:"#",onClick:this.handleClickOnAnchor},n);if(r&&r.startsWith("/")){if(r.startsWith("/#sonarcloud#/"))return o.createElement(P,{url:r},n);if(r.startsWith("/#sonarqube#/"))return o.createElement(N,{url:r},n);if(r.startsWith("/#sonarqube-admin#/"))return o.createElement(H,{canAdmin:t.canAdmin,url:r},n);{const e="/documentation"+r;return o.createElement(E.c,Object.assign({to:e},c),n)}}return o.createElement(o.Fragment,null,o.createElement("a",Object.assign({href:r,rel:"noopener noreferrer",target:"_blank"},c),n),o.createElement(j.a,{className:"text-muted little-spacer-left little-spacer-right text-baseline",size:12}))}}var A=Object(x.a)(S);function P({children:e,url:t}){if(Object(k.isSonarCloud)()){const n="/".concat(t.substr("/#sonarcloud#/".length));return o.createElement(E.c,{to:n},e)}return o.createElement(o.Fragment,null,e)}function N({children:e,url:t}){if(Object(k.isSonarCloud)())return o.createElement(o.Fragment,null,e);{const n="/".concat(t.substr("/#sonarqube#/".length));return o.createElement(E.c,{target:"_blank",to:n},e)}}function H({canAdmin:e,children:t,url:n}){if(Object(k.isSonarCloud)()||!e)return o.createElement(o.Fragment,null,t);{const e="/".concat(n.substr("/#sonarqube-admin#/".length));return o.createElement(E.c,{target:"_blank",to:e},t)}}n(899);var T=n(14),_=n.n(T),D=n(422),W=n.n(D),I=n(506),L=n(1094),M=n.n(L),q=n(6),F=n(1095),z=n.n(F);function U(){return function(e){const t=z()(e,{heading:"doctoc",maxDepth:2});null!==t.index&&-1!==t.index&&t.map?e.children=[t.map]:e.children=[]}}class J extends o.PureComponent{constructor(e){super(e),this.node=null,this.state={anchors:[]},this.scrollHandler=()=>{const e=Object(I.findDOMNode)(this);if(!e||!e.parentNode)return;const t=e.parentNode.querySelectorAll("h2[id]"),n=window.pageYOffset||document.body.scrollTop;let r;for(let e=0,o=t.length;e<o&&!(t.item(e).offsetTop>n+120);e++)r="#".concat(t.item(e).id);this.setState({highlightAnchor:r})},this.debouncedScrollHandler=W()(this.scrollHandler)}static getDerivedStateFromProps(e){const{content:t}=e;return{anchors:J.getAnchors(t)}}componentDidMount(){window.addEventListener("scroll",this.debouncedScrollHandler,!0),this.scrollHandler()}componentWillUnmount(){window.removeEventListener("scroll",this.debouncedScrollHandler,!0)}render(){const{anchors:e,highlightAnchor:t}=this.state;return 0===e.length?null:o.createElement("div",{className:"markdown-toc"},o.createElement("div",{className:"markdown-toc-content"},o.createElement("h4",null,Object(q.k)("documentation.on_this_page")),e.map(e=>o.createElement("a",{className:r({active:t===e.href}),href:e.href,key:e.title,onClick:t=>{this.props.onAnchorClick(e.href,t)}},e.title))))}}J.getAnchors=_()(e=>{const t=h()().use(M.a).use(U).processSync("\n## doctoc\n"+e);if(t&&t.contents.props.children){let e=t.contents,n=10;for(;n&&e.props.children.length&&"ul"!==e.type;)e=e.props.children[0],n--;if("ul"===e.type&&e.props.children.length)return e.props.children.map(e=>{if("string"==typeof e)return null;const t=e.props.children[0];return{href:t.props.href,title:t.props.children[0]}}).filter(e=>e)}return[]});var B=n(790),R=n.n(B);function Y(e,t){if(null==e)return{};var n,r,o=function(e,t){if(null==e)return{};var n,r,o={},l=Object.keys(e);for(r=0;r<l.length;r++)n=l[r],t.indexOf(n)>=0||(o[n]=e[n]);return o}(e,t);if(Object.getOwnPropertySymbols){var l=Object.getOwnPropertySymbols(e);for(r=0;r<l.length;r++)n=l[r],t.indexOf(n)>=0||Object.prototype.propertyIsEnumerable.call(e,n)&&(o[n]=e[n])}return o}function G(e){let{children:t,customProps:n,href:r}=e,l=Y(e,["children","customProps","href"]);return n&&R()(n,(e,t)=>{r&&(r=r.replace("#".concat(t,"#"),encodeURIComponent(e)))}),r&&r.startsWith("/")?(r=r.startsWith("/#sonarcloud#/")?"/".concat(r.substr("/#sonarcloud#/".length)):"/documentation/".concat(r.substr(1)),o.createElement(E.c,Object.assign({rel:"noopener noreferrer",target:"_blank",to:r},l),t)):o.createElement(o.Fragment,null,o.createElement("a",Object.assign({href:r,rel:"noopener noreferrer",target:"_blank"},l),t),o.createElement(j.a,{className:"little-spacer-left little-spacer-right text-baseline",size:12}))}class K extends o.PureComponent{constructor(){super(...arguments),this.node=null,this.handleAnchorClick=(e,t)=>{if(this.node){const n=this.node.querySelector(e);n&&(t&&t.preventDefault(),Object(g.b)(n,{bottomOffset:window.innerHeight-80}),history.pushState&&history.pushState(null,"",e))}}}componentDidMount(){const{scrollToHref:e}=this.props;e&&setTimeout(()=>{this.handleAnchorClick(e)},500)}render(){const{childProps:e,content:t,className:n,title:l,stickyToc:a,isTooltip:i}=this.props,d=h()();return d.use(f.a,{danger:{classes:"alert alert-danger"},warning:{classes:"alert alert-warning"},info:{classes:"alert alert-info"},success:{classes:"alert alert-success"},collapse:{classes:"collapse"}}).use(b.a,{allowDangerousHTML:!0}).use(u.a).use(c.a).use(s.a,{createElement:o.createElement,components:{div:V,a:i?Q(G,e):Q(A,{onAnchorClick:this.handleAnchorClick}),img:w}}),o.createElement("div",{className:r("markdown",n,{"has-toc":a}),ref:e=>this.node=e},o.createElement("div",{className:"markdown-content"},void 0!==l&&o.createElement("h1",{className:"documentation-title"},l),d.processSync(t).contents),a&&o.createElement(J,{content:t,onAnchorClick:this.handleAnchorClick}))}}function Q(e,t){return function(n){return o.createElement(e,Object.assign({customProps:t},n))}}function V(e){return e.className?e.className.includes("collapse")?o.createElement(y,null,e.children):o.createElement("div",{className:r("cut-margins",e.className)},e.children):e.children}},429:function(e,t,n){"use strict";n.d(t,"a",(function(){return c}));var r=n(366),o=n(372);function l(e,t){if(null==e)return{};var n,r,o=function(e,t){if(null==e)return{};var n,r,o={},l=Object.keys(e);for(r=0;r<l.length;r++)n=l[r],t.indexOf(n)>=0||(o[n]=e[n]);return o}(e,t);if(Object.getOwnPropertySymbols){var l=Object.getOwnPropertySymbols(e);for(r=0;r<l.length;r++)n=l[r],t.indexOf(n)>=0||Object.prototype.propertyIsEnumerable.call(e,n)&&(o[n]=e[n])}return o}function c(e){let{fill:t="currentColor"}=e,n=l(e,["fill"]);return r.createElement(o.a,Object.assign({},n),r.createElement("path",{d:"M12 9.25v2.5A2.25 2.25 0 0 1 9.75 14h-6.5A2.25 2.25 0 0 1 1 11.75v-6.5A2.25 2.25 0 0 1 3.25 3h5.5c.14 0 .25.11.25.25v.5c0 .14-.11.25-.25.25h-5.5C2.562 4 2 4.563 2 5.25v6.5c0 .688.563 1.25 1.25 1.25h6.5c.688 0 1.25-.563 1.25-1.25v-2.5c0-.14.11-.25.25-.25h.5c.14 0 .25.11.25.25zm3-6.75v4c0 .273-.227.5-.5.5a.497.497 0 0 1-.352-.148l-1.375-1.375L7.68 10.57a.27.27 0 0 1-.18.078.27.27 0 0 1-.18-.078l-.89-.89a.27.27 0 0 1-.078-.18.27.27 0 0 1 .078-.18l5.093-5.093-1.375-1.375A.497.497 0 0 1 10 2.5c0-.273.227-.5.5-.5h4c.273 0 .5.227.5.5z",style:{fill:t}}))}},466:function(e,t,n){"use strict";n.d(t,"a",(function(){return c}));var r=n(366),o=n(372);function l(e,t){if(null==e)return{};var n,r,o=function(e,t){if(null==e)return{};var n,r,o={},l=Object.keys(e);for(r=0;r<l.length;r++)n=l[r],t.indexOf(n)>=0||(o[n]=e[n]);return o}(e,t);if(Object.getOwnPropertySymbols){var l=Object.getOwnPropertySymbols(e);for(r=0;r<l.length;r++)n=l[r],t.indexOf(n)>=0||Object.prototype.propertyIsEnumerable.call(e,n)&&(o[n]=e[n])}return o}function c(e){let{fill:t="currentColor"}=e,n=l(e,["fill"]);return r.createElement(o.a,Object.assign({},n),r.createElement("path",{d:"M7.72 11.596L3.119 6.992A.382.382 0 0 1 3 6.713c0-.108.04-.2.118-.279l1.03-1.03a.382.382 0 0 1 .278-.117c.108 0 .201.04.28.117L8 8.7l3.294-3.295a.382.382 0 0 1 .28-.117c.108 0 .2.04.279.117l1.03 1.03a.382.382 0 0 1 .117.28c0 .107-.04.2-.118.278L8.28 11.596a.382.382 0 0 1-.279.117.382.382 0 0 1-.28-.117z",style:{fill:t}}))}},484:function(e,t,n){"use strict";n.d(t,"a",(function(){return a}));var r=n(366),o=n(466),l=n(460);function c(e,t){if(null==e)return{};var n,r,o=function(e,t){if(null==e)return{};var n,r,o={},l=Object.keys(e);for(r=0;r<l.length;r++)n=l[r],t.indexOf(n)>=0||(o[n]=e[n]);return o}(e,t);if(Object.getOwnPropertySymbols){var l=Object.getOwnPropertySymbols(e);for(r=0;r<l.length;r++)n=l[r],t.indexOf(n)>=0||Object.prototype.propertyIsEnumerable.call(e,n)&&(o[n]=e[n])}return o}function a(e){let{open:t}=e,n=c(e,["open"]);return t?r.createElement(o.a,Object.assign({},n)):r.createElement(l.a,Object.assign({},n))}},899:function(e,t,n){var r=n(369),o=n(900);"string"==typeof(o=o.__esModule?o.default:o)&&(o=[[e.i,o,""]]);var l={insert:"head",singleton:!1},c=(r(o,l),o.locals?o.locals:{});e.exports=c},900:function(e,t,n){(t=n(370)(!1)).push([e.i,".markdown-content .alert{margin-bottom:8px;border:1px solid;border-radius:2px}.markdown-content .alert.is-inline{display:inline-flex}.markdown-content .alert:empty{display:none}.markdown-content .alert-danger,.markdown-content .alert-error{border-color:#f4b1b0;background-color:#f2dede;color:#862422}.markdown-content .alert-danger .alert-icon,.markdown-content .alert-error .alert-icon{border-color:#f4b1b0}.markdown-content .alert-warning{border-color:#faebcc;background-color:#fcf8e3;color:#6f4f17}.markdown-content .alert-warning .alert-icon{border-color:#faebcc}.markdown-content .alert-info{border-color:#b1dff3;background-color:#d9edf7;color:#0e516f}.markdown-content .alert-info .alert-icon{border-color:#b1dff3}.markdown-content .alert-success{border-color:#d6e9c6;background-color:#dff0d8;color:#215821}.markdown-content .alert-success .alert-icon{border-color:#d6e9c6}",""]),e.exports=t}}]);
//# sourceMappingURL=339.m.c09ee942.chunk.js.map