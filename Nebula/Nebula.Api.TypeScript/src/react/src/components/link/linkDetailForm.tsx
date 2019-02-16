import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects'
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import LinkMapper from './linkMapper';
import LinkViewModel from './linkViewModel';

interface Props {
	history:any;
    model?:LinkViewModel
}

const LinkDetailDisplay = (model:Props) => {

   return (
          <form  role="form">
				<button
                  className="btn btn-primary btn-sm align-middle float-right vertically-center"
                  onClick={(e) => { model.history.push(ClientRoutes.Links + '/edit/' + model.model!.id)}}
                >
                  <i className="fas fa-edit" />
                </button>
			 						 <div className="form-group row">
							<label htmlFor="assignedMachineId" className={"col-sm-2 col-form-label"}>AssignedMachineId</label>
							<div className="col-sm-12">
								{model.model!.assignedMachineIdNavigation!.toDisplay()}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="chainId" className={"col-sm-2 col-form-label"}>ChainId</label>
							<div className="col-sm-12">
								{model.model!.chainIdNavigation!.toDisplay()}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="dateCompleted" className={"col-sm-2 col-form-label"}>DateCompleted</label>
							<div className="col-sm-12">
								{String(model.model!.dateCompleted)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="dateStarted" className={"col-sm-2 col-form-label"}>DateStarted</label>
							<div className="col-sm-12">
								{String(model.model!.dateStarted)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="dynamicParameter" className={"col-sm-2 col-form-label"}>DynamicParameter</label>
							<div className="col-sm-12">
								{String(model.model!.dynamicParameter)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="externalId" className={"col-sm-2 col-form-label"}>ExternalId</label>
							<div className="col-sm-12">
								{String(model.model!.externalId)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="id" className={"col-sm-2 col-form-label"}>Id</label>
							<div className="col-sm-12">
								{String(model.model!.id)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="linkStatusId" className={"col-sm-2 col-form-label"}>LinkStatusId</label>
							<div className="col-sm-12">
								{model.model!.linkStatusIdNavigation!.toDisplay()}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="name" className={"col-sm-2 col-form-label"}>Name</label>
							<div className="col-sm-12">
								{String(model.model!.name)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="order" className={"col-sm-2 col-form-label"}>Order</label>
							<div className="col-sm-12">
								{String(model.model!.order)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="response" className={"col-sm-2 col-form-label"}>Response</label>
							<div className="col-sm-12">
								{String(model.model!.response)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="staticParameter" className={"col-sm-2 col-form-label"}>StaticParameter</label>
							<div className="col-sm-12">
								{String(model.model!.staticParameter)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="timeoutInSecond" className={"col-sm-2 col-form-label"}>TimeoutInSecond</label>
							<div className="col-sm-12">
								{String(model.model!.timeoutInSecond)}
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

  interface LinkDetailComponentProps
  {
     match:IMatch;
	 history:any;
  }

  interface LinkDetailComponentState
  {
      model?:LinkViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }


  export default class LinkDetailComponent extends React.Component<LinkDetailComponentProps, LinkDetailComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiEndpoint + ApiRoutes.Links + '/' + this.props.match.params.id,
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.LinkClientResponseModel;
            
			let mapper = new LinkMapper();

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
            return (<LinkDetailDisplay history={this.props.history} model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>824bdb807b539f62eb78773601688724</Hash>
</Codenesium>*/