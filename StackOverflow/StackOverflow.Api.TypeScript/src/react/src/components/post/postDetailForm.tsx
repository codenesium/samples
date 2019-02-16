import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects'
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import PostMapper from './postMapper';
import PostViewModel from './postViewModel';

interface Props {
	history:any;
    model?:PostViewModel
}

const PostDetailDisplay = (model:Props) => {

   return (
          <form  role="form">
				<button
                  className="btn btn-primary btn-sm align-middle float-right vertically-center"
                  onClick={(e) => { model.history.push(ClientRoutes.Posts + '/edit/' + model.model!.id)}}
                >
                  <i className="fas fa-edit" />
                </button>
			 						 <div className="form-group row">
							<label htmlFor="acceptedAnswerId" className={"col-sm-2 col-form-label"}>AcceptedAnswerId</label>
							<div className="col-sm-12">
								{String(model.model!.acceptedAnswerId)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="answerCount" className={"col-sm-2 col-form-label"}>AnswerCount</label>
							<div className="col-sm-12">
								{String(model.model!.answerCount)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="body" className={"col-sm-2 col-form-label"}>Body</label>
							<div className="col-sm-12">
								{String(model.model!.body)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="closedDate" className={"col-sm-2 col-form-label"}>ClosedDate</label>
							<div className="col-sm-12">
								{String(model.model!.closedDate)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="commentCount" className={"col-sm-2 col-form-label"}>CommentCount</label>
							<div className="col-sm-12">
								{String(model.model!.commentCount)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="communityOwnedDate" className={"col-sm-2 col-form-label"}>CommunityOwnedDate</label>
							<div className="col-sm-12">
								{String(model.model!.communityOwnedDate)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="creationDate" className={"col-sm-2 col-form-label"}>CreationDate</label>
							<div className="col-sm-12">
								{String(model.model!.creationDate)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="favoriteCount" className={"col-sm-2 col-form-label"}>FavoriteCount</label>
							<div className="col-sm-12">
								{String(model.model!.favoriteCount)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="id" className={"col-sm-2 col-form-label"}>Id</label>
							<div className="col-sm-12">
								{String(model.model!.id)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="lastActivityDate" className={"col-sm-2 col-form-label"}>LastActivityDate</label>
							<div className="col-sm-12">
								{String(model.model!.lastActivityDate)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="lastEditDate" className={"col-sm-2 col-form-label"}>LastEditDate</label>
							<div className="col-sm-12">
								{String(model.model!.lastEditDate)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="lastEditorDisplayName" className={"col-sm-2 col-form-label"}>LastEditorDisplayName</label>
							<div className="col-sm-12">
								{String(model.model!.lastEditorDisplayName)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="lastEditorUserId" className={"col-sm-2 col-form-label"}>LastEditorUserId</label>
							<div className="col-sm-12">
								{String(model.model!.lastEditorUserId)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="ownerUserId" className={"col-sm-2 col-form-label"}>OwnerUserId</label>
							<div className="col-sm-12">
								{String(model.model!.ownerUserId)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="parentId" className={"col-sm-2 col-form-label"}>ParentId</label>
							<div className="col-sm-12">
								{String(model.model!.parentId)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="postTypeId" className={"col-sm-2 col-form-label"}>PostTypeId</label>
							<div className="col-sm-12">
								{String(model.model!.postTypeId)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="score" className={"col-sm-2 col-form-label"}>Score</label>
							<div className="col-sm-12">
								{String(model.model!.score)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="tag" className={"col-sm-2 col-form-label"}>Tags</label>
							<div className="col-sm-12">
								{String(model.model!.tag)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="title" className={"col-sm-2 col-form-label"}>Title</label>
							<div className="col-sm-12">
								{String(model.model!.title)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="viewCount" className={"col-sm-2 col-form-label"}>ViewCount</label>
							<div className="col-sm-12">
								{String(model.model!.viewCount)}
							</div>
						</div>
					             </form>
  );
}

  interface IParams 
  {
     id:number;
  }
  
  interface IMatch
  {
     params: IParams;
  }

  interface PostDetailComponentProps
  {
     match:IMatch;
	 history:any;
  }

  interface PostDetailComponentState
  {
      model?:PostViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }


  export default class PostDetailComponent extends React.Component<PostDetailComponentProps, PostDetailComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiEndpoint + ApiRoutes.Posts + '/' + this.props.match.params.id,
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.PostClientResponseModel;
            
			let mapper = new PostMapper();

            console.log(response);

            this.setState({model:mapper.mapApiResponseToViewModel(response), loading:false, loaded:true, errorOccurred:false, errorMessage:''});

        }, error => {
            console.log(error);
            this.setState({model:undefined, loading:false, loaded:false, errorOccurred:true, errorMessage:'Error from API'});
        })
    }
    render () {

        if (this.state.loading) {
            return <LoadingForm />;
        } 
		else if (this.state.errorOccurred) {
            return <ErrorForm message={this.state.errorMessage} />;
        }
        else if (this.state.loaded) {
            return (<PostDetailDisplay history={this.props.history} model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>d6ce331721f2809a27731eb80344b57c</Hash>
</Codenesium>*/