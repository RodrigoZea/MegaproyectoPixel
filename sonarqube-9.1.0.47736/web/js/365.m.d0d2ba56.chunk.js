(window.webpackJsonp=window.webpackJsonp||[]).push([[365],{1789:function(e,t,s){"use strict";s.r(t),s.d(t,"default",(function(){return G}));var a=s(366),n=s(393),r=s(903),o=s(396),l=s(404),i=s(414),c=s(6),m=s(4),d=s(368),u=s(391),h=s(376);function p({group:e,onClose:t,onSubmit:s}){const n=Object(c.k)("groups.delete_group");return a.createElement(u.a,{header:n,onClose:t,onSubmit:s},({onCloseClick:t,onFormSubmit:s,submitting:r})=>a.createElement("form",{onSubmit:s},a.createElement("header",{className:"modal-head"},a.createElement("h2",null,n)),a.createElement("div",{className:"modal-body"},Object(c.l)("groups.delete_group.confirmation",e.name)),a.createElement("footer",{className:"modal-foot"},a.createElement(h.a,{className:"spacer-right",loading:r}),a.createElement(d.h,{className:"button-red",disabled:r},Object(c.k)("delete")),a.createElement(d.g,{disabled:r,onClick:t},Object(c.k)("cancel")))))}var g=s(397),E=s(399);class b extends a.PureComponent{constructor(e){super(e),this.handleSubmit=()=>this.props.onSubmit({description:this.state.description,name:this.state.name}).then(this.props.onClose),this.handleDescriptionChange=e=>{this.setState({description:e.currentTarget.value})},this.handleNameChange=e=>{this.setState({name:e.currentTarget.value})},this.state={description:e.group&&e.group.description||"",name:e.group&&e.group.name||""}}render(){return a.createElement(u.a,{header:this.props.header,onClose:this.props.onClose,onSubmit:this.handleSubmit,size:"small"},({onCloseClick:e,onFormSubmit:t,submitting:s})=>a.createElement("form",{onSubmit:t},a.createElement("header",{className:"modal-head"},a.createElement("h2",null,this.props.header)),a.createElement("div",{className:"modal-body"},a.createElement(E.a,{className:"modal-field"}),a.createElement("div",{className:"modal-field"},a.createElement("label",{htmlFor:"create-group-name"},Object(c.k)("name"),a.createElement(g.a,null)),a.createElement("input",{autoFocus:!0,id:"create-group-name",maxLength:255,name:"name",onChange:this.handleNameChange,required:!0,size:50,type:"text",value:this.state.name})),a.createElement("div",{className:"modal-field"},a.createElement("label",{htmlFor:"create-group-description"},Object(c.k)("description")),a.createElement("textarea",{id:"create-group-description",name:"description",onChange:this.handleDescriptionChange,value:this.state.description}))),a.createElement("footer",{className:"modal-foot"},a.createElement(h.a,{className:"spacer-right",loading:s}),a.createElement(d.h,{disabled:s},this.props.confirmButtonText),a.createElement(d.g,{onClick:e},Object(c.k)("cancel")))))}}class f extends a.PureComponent{constructor(){super(...arguments),this.mounted=!1,this.state={createModal:!1},this.handleCreateClick=()=>{this.setState({createModal:!0})},this.handleClose=()=>{this.mounted&&this.setState({createModal:!1})},this.handleSubmit=e=>this.props.onCreate(e)}componentDidMount(){this.mounted=!0}componentWillUnmount(){this.mounted=!1}render(){return a.createElement(a.Fragment,null,a.createElement("header",{className:"page-header",id:"groups-header"},a.createElement("h1",{className:"page-title"},Object(c.k)("user_groups.page")),a.createElement("div",{className:"page-actions"},a.createElement(d.a,{id:"groups-create",onClick:this.handleCreateClick},Object(c.k)("groups.create_group"))),a.createElement("p",{className:"page-description"},Object(c.k)("user_groups.page.description"))),this.state.createModal&&a.createElement(b,{confirmButtonText:Object(c.k)("create"),header:Object(c.k)("groups.create_group"),onClose:this.handleClose,onSubmit:this.handleSubmit}))}}var C=s(387),j=s.n(C),O=s(437),S=s(639),k=s(405),N=s.n(k),y=s(521),v=s.n(y),w=s(389),D=s(571);class x extends a.PureComponent{constructor(e){super(e),this.mounted=!1,this.fetchUsers=e=>Object(r.d)({name:this.props.group.name,p:e.page,ps:e.pageSize,q:""!==e.query?e.query:void 0,selected:e.filter}).then(t=>{this.mounted&&this.setState(s=>{const a=null!=e.page&&e.page>1,n=a?[...s.users,...t.users]:t.users,r=t.users.filter(e=>e.selected).map(e=>e.login),o=a?[...s.selectedUsers,...r]:r;return{needToReload:!1,lastSearchParams:e,loading:!1,users:n,usersTotalCount:t.total,selectedUsers:o}})}),this.handleSelect=e=>Object(r.a)({name:this.props.group.name,login:e}).then(()=>{this.mounted&&this.setState(t=>({needToReload:!0,selectedUsers:[...t.selectedUsers,e]}))}),this.handleUnselect=e=>Object(r.e)({name:this.props.group.name,login:e}).then(()=>{this.mounted&&this.setState(t=>({needToReload:!0,selectedUsers:N()(t.selectedUsers,e)}))}),this.renderElement=e=>{const t=v()(this.state.users,{login:e});return a.createElement("div",{className:"select-list-list-item"},void 0===t?e:a.createElement(a.Fragment,null,t.name,a.createElement("br",null),a.createElement("span",{className:"note"},t.login)))},this.state={needToReload:!1,users:[],selectedUsers:[]}}componentDidMount(){this.mounted=!0}componentWillUnmount(){this.mounted=!1}render(){const e=Object(c.k)("users.update");return a.createElement(w.a,{contentLabel:e,onRequestClose:this.props.onClose},a.createElement("header",{className:"modal-head"},a.createElement("h2",null,e)),a.createElement("div",{className:"modal-body modal-container"},a.createElement(D.b,{elements:this.state.users.map(e=>e.login),elementsTotalCount:this.state.usersTotalCount,needToReload:this.state.needToReload&&this.state.lastSearchParams&&this.state.lastSearchParams.filter!==D.a.All,onSearch:this.fetchUsers,onSelect:this.handleSelect,onUnselect:this.handleUnselect,renderElement:this.renderElement,selectedElements:this.state.selectedUsers,withPaging:!0})),a.createElement("footer",{className:"modal-foot"},a.createElement(d.g,{onClick:this.props.onClose},Object(c.k)("Done"))))}}class F extends a.PureComponent{constructor(){super(...arguments),this.mounted=!1,this.state={modal:!1},this.handleMembersClick=()=>{this.setState({modal:!0})},this.handleModalClose=()=>{this.mounted&&(this.setState({modal:!1}),this.props.onEdit())}}componentDidMount(){this.mounted=!0}componentWillUnmount(){this.mounted=!1}render(){return a.createElement(a.Fragment,null,a.createElement(d.b,{"aria-label":Object(c.k)("groups.users.edit"),className:"button-small",onClick:this.handleMembersClick,title:Object(c.k)("groups.users.edit")},a.createElement(S.a,null)),this.state.modal&&a.createElement(x,{group:this.props.group,onClose:this.handleModalClose}))}}function M(e){const{group:t}=e;return a.createElement("tr",{"data-id":t.name},a.createElement("td",{className:"width-20"},a.createElement("strong",{className:"js-group-name"},t.name),t.default&&a.createElement("span",{className:"little-spacer-left"},"(",Object(c.k)("default"),")")),a.createElement("td",{className:"thin text-middle text-right little-padded-right"},t.membersCount),a.createElement("td",{className:"little-padded-left"},!t.default&&a.createElement(F,{group:t,onEdit:e.onEditMembers})),a.createElement("td",{className:"width-40"},a.createElement("span",{className:"js-group-description"},t.description)),a.createElement("td",{className:"thin nowrap text-right"},!t.default&&a.createElement(O.c,null,a.createElement(O.b,{className:"js-group-update",onClick:()=>e.onEdit(t)},Object(c.k)("update_details")),a.createElement(O.a,null),a.createElement(O.b,{className:"js-group-delete",destructive:!0,onClick:()=>e.onDelete(t)},Object(c.k)("delete")))))}function T(e){return a.createElement("div",{className:"boxed-group boxed-group-inner"},a.createElement("table",{className:"data zebra zebra-hover",id:"groups-list"},a.createElement("thead",null,a.createElement("tr",null,a.createElement("th",null),a.createElement("th",{className:"nowrap width-10",colSpan:2},Object(c.k)("members")),a.createElement("th",{className:"nowrap"},Object(c.k)("description")),a.createElement("th",null))),a.createElement("tbody",null,e.showAnyone&&a.createElement("tr",{className:"js-anyone",key:"anyone"},a.createElement("td",{className:"width-20"},a.createElement("strong",{className:"js-group-name"},Object(c.k)("groups.anyone"))),a.createElement("td",{className:"width-10",colSpan:2}),a.createElement("td",{className:"width-40",colSpan:2},a.createElement("span",{className:"js-group-description"},Object(c.k)("user_groups.anyone.description")))),j()(e.groups,e=>e.name.toLowerCase()).map(t=>a.createElement(M,{group:t,key:t.name,onDelete:e.onDelete,onEdit:e.onEdit,onEditMembers:e.onEditMembers})))))}function P(e,t){var s=Object.keys(e);if(Object.getOwnPropertySymbols){var a=Object.getOwnPropertySymbols(e);t&&(a=a.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),s.push.apply(s,a)}return s}function U(e){for(var t=1;t<arguments.length;t++){var s=null!=arguments[t]?arguments[t]:{};t%2?P(Object(s),!0).forEach((function(t){q(e,t,s[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(s)):P(Object(s)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(s,t))}))}return e}function q(e,t,s){return t in e?Object.defineProperty(e,t,{value:s,enumerable:!0,configurable:!0,writable:!0}):e[t]=s,e}class G extends a.PureComponent{constructor(){super(...arguments),this.mounted=!1,this.state={loading:!0,query:""},this.makeFetchGroupsRequest=e=>(this.setState({loading:!0}),Object(r.f)(U({q:this.state.query},e))),this.stopLoading=()=>{this.mounted&&this.setState({loading:!1})},this.fetchGroups=async e=>{try{const{groups:t,paging:s}=await this.makeFetchGroupsRequest(e);this.mounted&&this.setState({groups:t,loading:!1,paging:s})}catch(e){this.stopLoading()}},this.fetchMoreGroups=async()=>{const{paging:e}=this.state;if(e&&e.total>e.pageIndex*e.pageSize)try{const{groups:t,paging:s}=await this.makeFetchGroupsRequest({p:e.pageIndex+1});this.mounted&&this.setState(({groups:e=[]})=>({groups:[...e,...t],loading:!1,paging:s}))}catch(e){this.stopLoading()}},this.search=e=>{this.fetchGroups({q:e}),this.setState({query:e})},this.refresh=async()=>{const{paging:e,query:t}=this.state;if(await this.fetchGroups({q:t}),e&&e.pageIndex>1)for(let t=1;t<e.pageIndex;t++)await this.fetchMoreGroups()},this.closeDeleteForm=()=>{this.setState({groupToBeDeleted:void 0})},this.closeEditForm=()=>{this.setState({editedGroup:void 0})},this.openDeleteForm=e=>{this.setState({groupToBeDeleted:e})},this.openEditForm=e=>{this.setState({editedGroup:e})},this.handleCreate=async e=>{await Object(r.b)(U({},e)),await this.refresh()},this.handleDelete=async()=>{const{groupToBeDeleted:e}=this.state;e&&(await Object(r.c)({name:e.name}),await this.refresh(),this.mounted&&this.setState({groupToBeDeleted:void 0}))},this.handleEdit=async({name:e,description:t})=>{const{editedGroup:s}=this.state;if(!s)return;const a=U({description:t,id:s.id},Object(m.f)({name:e!==s.name?e:void 0}));await Object(r.g)(a),this.mounted&&this.setState(({groups:e=[]})=>({editedGroup:void 0,groups:e.map(e=>e.name===s.name?U({},e,{},a):e)}))}}componentDidMount(){this.mounted=!0,this.fetchGroups()}componentWillUnmount(){this.mounted=!1}render(){const{editedGroup:e,groupToBeDeleted:t,groups:s,loading:r,paging:m,query:d}=this.state,u="anyone".includes(d.toLowerCase());return a.createElement(a.Fragment,null,a.createElement(o.a,{suggestions:"user_groups"}),a.createElement(n.a,{defer:!1,title:Object(c.k)("user_groups.page")}),a.createElement("div",{className:"page page-limited",id:"groups-page"},a.createElement(f,{onCreate:this.handleCreate}),a.createElement(i.a,{className:"big-spacer-bottom",id:"groups-search",minLength:2,onChange:this.search,placeholder:Object(c.k)("search.search_by_name"),value:d}),void 0!==s&&a.createElement(T,{groups:s,onDelete:this.openDeleteForm,onEdit:this.openEditForm,onEditMembers:this.refresh,showAnyone:u}),void 0!==s&&void 0!==m&&a.createElement("div",{id:"groups-list-footer"},a.createElement(l.a,{count:u?s.length+1:s.length,loading:r,loadMore:this.fetchMoreGroups,ready:!r,total:u?m.total+1:m.total})),t&&a.createElement(p,{group:t,onClose:this.closeDeleteForm,onSubmit:this.handleDelete}),e&&a.createElement(b,{confirmButtonText:Object(c.k)("update_verb"),group:e,header:Object(c.k)("groups.update_group"),onClose:this.closeEditForm,onSubmit:this.handleEdit})))}}}}]);
//# sourceMappingURL=365.m.d0d2ba56.chunk.js.map