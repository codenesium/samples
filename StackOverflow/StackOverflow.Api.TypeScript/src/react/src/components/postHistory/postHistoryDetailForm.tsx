import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects'
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import PostHistoryMapper from './postHistoryMapper';
import PostHistoryViewModel from './postHistoryViewModel';

interface Props {
	history:any;
    model?:PostHistoryViewModel
}

const PostHistoryDetailDisplay = (model:Props) => {

   return (
          <form  role="form">
				<button
                  className="btn btn-primary btn-sm align-middle float-right vertically-center"
                  onClick={(e) => { model.history.push(ClientRoutes.PostHistories + '/edit/' + model.model!.id)}}
                >
                  <i className="fas fa-edit" />
                </button>
			 						 <div className="form-group row">
							<label htmlFor="comment" className={"col-sm-2 col-form-label"}>Comment</label>
							<div className="col-sm-12">
								{String(model.model!.comment)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="creationDate" className={"col-sm-2 col-form-label"}>CreationDate</label>
							<div className="col-sm-12">
								{String(model.model!.creationDate)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="id" className={"col-sm-2 col-form-label"}>Id</label>
							<div className="col-sm-12">
								{String(model.model!.id)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="postHistoryTypeId" className={"col-sm-2 col-form-label"}>PostHistoryTypeId</label>
							<div className="col-sm-12">
								{String(model.model!.postHistoryTypeId)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="postId" className={"col-sm-2 col-form-label"}>PostId</label>
							<div className="col-sm-12">
								{String(model.model!.postId)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="revisionGUID" className={"col-sm-2 col-form-label"}>RevisionGUID</label>
							<div className="col-sm-12">
								{String(model.model!.revisionGUID)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="text" className={"col-sm-2 col-form-label"}>Text</label>
							<div className="col-sm-12">
								{String(model.model!.text)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="userDisplayName" className={"col-sm-2 col-form-label"}>UserDisplayName</label>
							<div className="col-sm-12">
								{String(model.model!.userDisplayName)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="userId" className={"col-sm-2 col-form-label"}>UserId</label>
							<div className="col-sm-12">
								{String(model.model!.userId)}
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

  interface PostHistoryDetailComponentProps
  {
     match:IMatch;
	 history:any;
  }

  interface PostHistoryDetailComponentState
  {
      model?:PostHistoryViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }


  export default class PostHistoryDetailComponent extends React.Component<PostHistoryDetailComponentProps, PostHistoryDetailComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiEndpoint + ApiRoutes.PostHistories + '/' + this.props.match.params.id,
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.PostHistoryClientResponseModel;
            
			let mapper = new PostHistoryMapper();

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
            return (<PostHistoryDetailDisplay history={this.props.history} model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>641fc4d7c8403c872fa20d069b375ae6</Hash>
</Codenesium>*/