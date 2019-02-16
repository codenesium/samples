import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects'
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import PostViewModel from './postViewModel';
import PostMapper from './postMapper';

interface Props {
    model?:PostViewModel
}

  const PostEditDisplay = (props: FormikProps<PostViewModel>) => {

   let status = props.status as UpdateResponse<Api.PostClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   { 
        let response = '';
        if(props.touched[name as keyof PostViewModel]  && props.errors[name as keyof PostViewModel]) {
            response += props.errors[name as keyof PostViewModel];
        }

        if(status && status.validationErrors && status.validationErrors.find(f => f.propertyName.toLowerCase() == name.toLowerCase())) {
            response += status.validationErrors.filter(f => f.propertyName.toLowerCase() == name.toLowerCase())[0].errorMessage;
        }

        return response;
   }

    
   let errorExistForField = (name:string) : boolean =>
   {
        return errorsForField(name) != '';
   }

   return (

          <form onSubmit={props.handleSubmit} role="form">
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("acceptedAnswerId") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>AcceptedAnswerId</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="acceptedAnswerId" className={errorExistForField("acceptedAnswerId") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("acceptedAnswerId") && <small className="text-danger">{errorsForField("acceptedAnswerId")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("answerCount") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>AnswerCount</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="answerCount" className={errorExistForField("answerCount") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("answerCount") && <small className="text-danger">{errorsForField("answerCount")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("body") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Body</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="body" className={errorExistForField("body") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("body") && <small className="text-danger">{errorsForField("body")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("closedDate") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>ClosedDate</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="closedDate" className={errorExistForField("closedDate") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("closedDate") && <small className="text-danger">{errorsForField("closedDate")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("commentCount") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>CommentCount</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="commentCount" className={errorExistForField("commentCount") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("commentCount") && <small className="text-danger">{errorsForField("commentCount")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("communityOwnedDate") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>CommunityOwnedDate</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="communityOwnedDate" className={errorExistForField("communityOwnedDate") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("communityOwnedDate") && <small className="text-danger">{errorsForField("communityOwnedDate")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("creationDate") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>CreationDate</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="creationDate" className={errorExistForField("creationDate") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("creationDate") && <small className="text-danger">{errorsForField("creationDate")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("favoriteCount") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>FavoriteCount</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="favoriteCount" className={errorExistForField("favoriteCount") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("favoriteCount") && <small className="text-danger">{errorsForField("favoriteCount")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("lastActivityDate") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>LastActivityDate</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="lastActivityDate" className={errorExistForField("lastActivityDate") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("lastActivityDate") && <small className="text-danger">{errorsForField("lastActivityDate")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("lastEditDate") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>LastEditDate</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="lastEditDate" className={errorExistForField("lastEditDate") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("lastEditDate") && <small className="text-danger">{errorsForField("lastEditDate")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("lastEditorDisplayName") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>LastEditorDisplayName</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="lastEditorDisplayName" className={errorExistForField("lastEditorDisplayName") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("lastEditorDisplayName") && <small className="text-danger">{errorsForField("lastEditorDisplayName")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("lastEditorUserId") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>LastEditorUserId</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="lastEditorUserId" className={errorExistForField("lastEditorUserId") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("lastEditorUserId") && <small className="text-danger">{errorsForField("lastEditorUserId")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("ownerUserId") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>OwnerUserId</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="ownerUserId" className={errorExistForField("ownerUserId") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("ownerUserId") && <small className="text-danger">{errorsForField("ownerUserId")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("parentId") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>ParentId</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="parentId" className={errorExistForField("parentId") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("parentId") && <small className="text-danger">{errorsForField("parentId")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("postTypeId") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>PostTypeId</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="postTypeId" className={errorExistForField("postTypeId") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("postTypeId") && <small className="text-danger">{errorsForField("postTypeId")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("score") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Score</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="score" className={errorExistForField("score") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("score") && <small className="text-danger">{errorsForField("score")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("tag") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Tags</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="tag" className={errorExistForField("tag") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("tag") && <small className="text-danger">{errorsForField("tag")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("title") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Title</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="title" className={errorExistForField("title") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("title") && <small className="text-danger">{errorsForField("title")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("viewCount") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>ViewCount</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="viewCount" className={errorExistForField("viewCount") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("viewCount") && <small className="text-danger">{errorsForField("viewCount")}</small>}
                        </div>
                    </div>
			
            <button type="submit" className="btn btn-primary" disabled={false}>
                Submit
            </button>
            <br />
            <br />
            { 
                status && status.success ? (<div className="alert alert-success">Success</div>): (null)
            }
                        
            { 
                status && !status.success ? (<div className="alert alert-danger">Error occurred</div>): (null)
            }
          </form>
  );
}


const PostEdit = withFormik<Props, PostViewModel>({
    mapPropsToValues: props => {
        let response = new PostViewModel();
		response.setProperties(props.model!.acceptedAnswerId,props.model!.answerCount,props.model!.body,props.model!.closedDate,props.model!.commentCount,props.model!.communityOwnedDate,props.model!.creationDate,props.model!.favoriteCount,props.model!.id,props.model!.lastActivityDate,props.model!.lastEditDate,props.model!.lastEditorDisplayName,props.model!.lastEditorUserId,props.model!.ownerUserId,props.model!.parentId,props.model!.postTypeId,props.model!.score,props.model!.tag,props.model!.title,props.model!.viewCount);	
		return response;
      },
  
    // Custom sync validation
    validate: values => {
      let errors:FormikErrors<PostViewModel> = { };

	  if(values.body == '') {
                errors.body = "Required"
                    }if(values.creationDate == undefined) {
                errors.creationDate = "Required"
                    }if(values.id == 0) {
                errors.id = "Required"
                    }if(values.lastActivityDate == undefined) {
                errors.lastActivityDate = "Required"
                    }if(values.postTypeId == 0) {
                errors.postTypeId = "Required"
                    }if(values.score == 0) {
                errors.score = "Required"
                    }if(values.viewCount == 0) {
                errors.viewCount = "Required"
                    }

      return errors;
    },
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
		  
	    let mapper = new PostMapper();

        axios.put(Constants.ApiEndpoint + ApiRoutes.Posts +'/' + values.id,
           
	    mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as UpdateResponse<Api.PostClientRequestModel>;
            actions.setStatus(response);
            console.log(response);
        }, 
		error => {
		    console.log(error);
            actions.setStatus('Error from API');
        })
        .then(response =>
        {
            // cleanup
        })
    },
  
    displayName: 'PostEdit', 
  })(PostEditDisplay);

 
  interface IParams 
  {
     id:number;
  }

  interface IMatch
  {
     params: IParams;
  }
  
  interface PostEditComponentProps
  {
     match:IMatch;
  }

  interface PostEditComponentState
  {
      model?:PostViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class PostEditComponent extends React.Component<PostEditComponentProps, PostEditComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiEndpoint + ApiRoutes.Posts + '/' + this.props.match.params.id, {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.PostClientResponseModel;
            
            console.log(response);

			let mapper = new PostMapper();

            this.setState({model:mapper.mapApiResponseToViewModel(response), loading:false, loaded:true, errorOccurred:false, errorMessage:''});

        }, 
		error => {
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
            return (<PostEdit model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>ca0ba1a7b5d9ae2ad30c5e8bcc6ce019</Hash>
</Codenesium>*/