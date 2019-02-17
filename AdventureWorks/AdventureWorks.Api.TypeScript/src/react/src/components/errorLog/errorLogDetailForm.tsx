import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects'
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import ErrorLogMapper from './errorLogMapper';
import ErrorLogViewModel from './errorLogViewModel';

interface Props {
	history:any;
    model?:ErrorLogViewModel
}

const ErrorLogDetailDisplay = (model:Props) => {

   return (
          <form  role="form">
				<button
                  className="btn btn-primary btn-sm align-middle float-right vertically-center"
                  onClick={(e) => { model.history.push(ClientRoutes.ErrorLogs + '/edit/' + model.model!.errorLogID)}}
                >
                  <i className="fas fa-edit" />
                </button>
			 						 <div className="form-group row">
							<label htmlFor="errorLine" className={"col-sm-2 col-form-label"}>ErrorLine</label>
							<div className="col-sm-12">
								{String(model.model!.errorLine)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="errorLogID" className={"col-sm-2 col-form-label"}>ErrorLogID</label>
							<div className="col-sm-12">
								{String(model.model!.errorLogID)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="errorMessage" className={"col-sm-2 col-form-label"}>ErrorMessage</label>
							<div className="col-sm-12">
								{String(model.model!.errorMessage)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="errorNumber" className={"col-sm-2 col-form-label"}>ErrorNumber</label>
							<div className="col-sm-12">
								{String(model.model!.errorNumber)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="errorProcedure" className={"col-sm-2 col-form-label"}>ErrorProcedure</label>
							<div className="col-sm-12">
								{String(model.model!.errorProcedure)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="errorSeverity" className={"col-sm-2 col-form-label"}>ErrorSeverity</label>
							<div className="col-sm-12">
								{String(model.model!.errorSeverity)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="errorState" className={"col-sm-2 col-form-label"}>ErrorState</label>
							<div className="col-sm-12">
								{String(model.model!.errorState)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="errorTime" className={"col-sm-2 col-form-label"}>ErrorTime</label>
							<div className="col-sm-12">
								{String(model.model!.errorTime)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="userName" className={"col-sm-2 col-form-label"}>UserName</label>
							<div className="col-sm-12">
								{String(model.model!.userName)}
							</div>
						</div>
					             </form>
  );
}

  interface IParams 
  {
     errorLogID:number;
  }
  
  interface IMatch
  {
     params: IParams;
  }

  interface ErrorLogDetailComponentProps
  {
     match:IMatch;
	 history:any;
  }

  interface ErrorLogDetailComponentState
  {
      model?:ErrorLogViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }


  export default class ErrorLogDetailComponent extends React.Component<ErrorLogDetailComponentProps, ErrorLogDetailComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiEndpoint + ApiRoutes.ErrorLogs + '/' + this.props.match.params.errorLogID,
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.ErrorLogClientResponseModel;
            
			let mapper = new ErrorLogMapper();

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
            return (<ErrorLogDetailDisplay history={this.props.history} model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>412394ea4e4682065ad4b942ea9467e5</Hash>
</Codenesium>*/