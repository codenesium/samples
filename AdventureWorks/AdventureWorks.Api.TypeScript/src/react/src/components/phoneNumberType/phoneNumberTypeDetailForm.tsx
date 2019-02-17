import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects'
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import PhoneNumberTypeMapper from './phoneNumberTypeMapper';
import PhoneNumberTypeViewModel from './phoneNumberTypeViewModel';

interface Props {
	history:any;
    model?:PhoneNumberTypeViewModel
}

const PhoneNumberTypeDetailDisplay = (model:Props) => {

   return (
          <form  role="form">
				<button
                  className="btn btn-primary btn-sm align-middle float-right vertically-center"
                  onClick={(e) => { model.history.push(ClientRoutes.PhoneNumberTypes + '/edit/' + model.model!.phoneNumberTypeID)}}
                >
                  <i className="fas fa-edit" />
                </button>
			 						 <div className="form-group row">
							<label htmlFor="modifiedDate" className={"col-sm-2 col-form-label"}>ModifiedDate</label>
							<div className="col-sm-12">
								{String(model.model!.modifiedDate)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="name" className={"col-sm-2 col-form-label"}>Name</label>
							<div className="col-sm-12">
								{String(model.model!.name)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="phoneNumberTypeID" className={"col-sm-2 col-form-label"}>PhoneNumberTypeID</label>
							<div className="col-sm-12">
								{String(model.model!.phoneNumberTypeID)}
							</div>
						</div>
					             </form>
  );
}

  interface IParams 
  {
     phoneNumberTypeID:number;
  }
  
  interface IMatch
  {
     params: IParams;
  }

  interface PhoneNumberTypeDetailComponentProps
  {
     match:IMatch;
	 history:any;
  }

  interface PhoneNumberTypeDetailComponentState
  {
      model?:PhoneNumberTypeViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }


  export default class PhoneNumberTypeDetailComponent extends React.Component<PhoneNumberTypeDetailComponentProps, PhoneNumberTypeDetailComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiEndpoint + ApiRoutes.PhoneNumberTypes + '/' + this.props.match.params.phoneNumberTypeID,
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.PhoneNumberTypeClientResponseModel;
            
			let mapper = new PhoneNumberTypeMapper();

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
            return (<PhoneNumberTypeDetailDisplay history={this.props.history} model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>03a6b9e09f660e26ca82c664aa07edef</Hash>
</Codenesium>*/