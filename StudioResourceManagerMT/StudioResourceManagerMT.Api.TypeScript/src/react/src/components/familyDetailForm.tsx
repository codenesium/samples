import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../api/models';
import {UpdateResponse} from '../api/ApiObjects'
import Constants from '../constants'
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import FamilyMapper from '../mapping/familyMapper';
import FamilyViewModel from '../viewmodels/familyViewModel';

interface Props {
    model?:FamilyViewModel
}

const FamilyDetailDisplay = (model:Props) => {

   return (
          <form  role="form">
			 				
				 <div className="form-group row">
					<label htmlFor="id" className={"col-sm-2 col-form-label"}>Id</label>
					<div className="col-sm-12">
						{model.model!.id}
					</div>
				</div>

			   				
				 <div className="form-group row">
					<label htmlFor="isDeleted" className={"col-sm-2 col-form-label"}>IsDeleted</label>
					<div className="col-sm-12">
						{model.model!.isDeleted}
					</div>
				</div>

			   				
				 <div className="form-group row">
					<label htmlFor="note" className={"col-sm-2 col-form-label"}>Note</label>
					<div className="col-sm-12">
						{model.model!.note}
					</div>
				</div>

			   				
				 <div className="form-group row">
					<label htmlFor="primaryContactEmail" className={"col-sm-2 col-form-label"}>PrimaryContactEmail</label>
					<div className="col-sm-12">
						{model.model!.primaryContactEmail}
					</div>
				</div>

			   				
				 <div className="form-group row">
					<label htmlFor="primaryContactFirstName" className={"col-sm-2 col-form-label"}>PrimaryContactFirstName</label>
					<div className="col-sm-12">
						{model.model!.primaryContactFirstName}
					</div>
				</div>

			   				
				 <div className="form-group row">
					<label htmlFor="primaryContactLastName" className={"col-sm-2 col-form-label"}>PrimaryContactLastName</label>
					<div className="col-sm-12">
						{model.model!.primaryContactLastName}
					</div>
				</div>

			   				
				 <div className="form-group row">
					<label htmlFor="primaryContactPhone" className={"col-sm-2 col-form-label"}>PrimaryContactPhone</label>
					<div className="col-sm-12">
						{model.model!.primaryContactPhone}
					</div>
				</div>

			   				
				 <div className="form-group row">
					<label htmlFor="tenantId" className={"col-sm-2 col-form-label"}>TenantId</label>
					<div className="col-sm-12">
						{model.model!.tenantId}
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

  interface FamilyDetailComponentProps
  {
     match:IMatch;
  }

  interface FamilyDetailComponentState
  {
      model?:FamilyViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }


  export default class FamilyDetailComponent extends React.Component<FamilyDetailComponentProps, FamilyDetailComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiUrl + 'families/' + this.props.match.params.id,
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.FamilyClientResponseModel;
            
			let mapper = new FamilyMapper();

            console.log(response);

            this.setState({model:mapper.mapApiResponseToViewModel(response), loading:false, loaded:true, errorOccurred:false, errorMessage:''});

        }, error => {
            let response = error.response.data as UpdateResponse<Api.FamilyClientRequestModel>;
            this.setState({model:undefined, loading:false, loaded:false, errorOccurred:true, errorMessage:'Error from API'});
            console.log(response);
        })
    }
    render () {

        if (this.state.loading) {
            return (<div>loading</div>);
        } 
        else if (this.state.loaded) {
            return (<FamilyDetailDisplay model={this.state.model} />);
        } 
        else if (this.state.errorOccurred) {
            return (<div>{this.state.errorMessage}</div>);
        }
        else {
            return (<div></div>);   
        }
    }
}

/*<Codenesium>
    <Hash>4cd3b4a15665eac64cb44038d4fa8c07</Hash>
</Codenesium>*/