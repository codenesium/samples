import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects'
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import EmployeeMapper from './employeeMapper';
import EmployeeViewModel from './employeeViewModel';

interface Props {
	history:any;
    model?:EmployeeViewModel
}

const EmployeeDetailDisplay = (model:Props) => {

   return (
          <form  role="form">
				<button
                  className="btn btn-primary btn-sm align-middle float-right vertically-center"
                  onClick={(e) => { model.history.push(ClientRoutes.Employees + '/edit/' + model.model!.businessEntityID)}}
                >
                  <i className="fas fa-edit" />
                </button>
			 						 <div className="form-group row">
							<label htmlFor="birthDate" className={"col-sm-2 col-form-label"}>BirthDate</label>
							<div className="col-sm-12">
								{String(model.model!.birthDate)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="businessEntityID" className={"col-sm-2 col-form-label"}>BusinessEntityID</label>
							<div className="col-sm-12">
								{String(model.model!.businessEntityID)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="currentFlag" className={"col-sm-2 col-form-label"}>CurrentFlag</label>
							<div className="col-sm-12">
								{String(model.model!.currentFlag)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="gender" className={"col-sm-2 col-form-label"}>Gender</label>
							<div className="col-sm-12">
								{String(model.model!.gender)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="hireDate" className={"col-sm-2 col-form-label"}>HireDate</label>
							<div className="col-sm-12">
								{String(model.model!.hireDate)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="jobTitle" className={"col-sm-2 col-form-label"}>JobTitle</label>
							<div className="col-sm-12">
								{String(model.model!.jobTitle)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="loginID" className={"col-sm-2 col-form-label"}>LoginID</label>
							<div className="col-sm-12">
								{String(model.model!.loginID)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="maritalStatu" className={"col-sm-2 col-form-label"}>MaritalStatus</label>
							<div className="col-sm-12">
								{String(model.model!.maritalStatu)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="modifiedDate" className={"col-sm-2 col-form-label"}>ModifiedDate</label>
							<div className="col-sm-12">
								{String(model.model!.modifiedDate)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="nationalIDNumber" className={"col-sm-2 col-form-label"}>NationalIDNumber</label>
							<div className="col-sm-12">
								{String(model.model!.nationalIDNumber)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="organizationLevel" className={"col-sm-2 col-form-label"}>OrganizationLevel</label>
							<div className="col-sm-12">
								{String(model.model!.organizationLevel)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="rowguid" className={"col-sm-2 col-form-label"}>Rowguid</label>
							<div className="col-sm-12">
								{String(model.model!.rowguid)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="salariedFlag" className={"col-sm-2 col-form-label"}>SalariedFlag</label>
							<div className="col-sm-12">
								{String(model.model!.salariedFlag)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="sickLeaveHour" className={"col-sm-2 col-form-label"}>SickLeaveHours</label>
							<div className="col-sm-12">
								{String(model.model!.sickLeaveHour)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="vacationHour" className={"col-sm-2 col-form-label"}>VacationHours</label>
							<div className="col-sm-12">
								{String(model.model!.vacationHour)}
							</div>
						</div>
					             </form>
  );
}

  interface IParams 
  {
     businessEntityID:number;
  }
  
  interface IMatch
  {
     params: IParams;
  }

  interface EmployeeDetailComponentProps
  {
     match:IMatch;
	 history:any;
  }

  interface EmployeeDetailComponentState
  {
      model?:EmployeeViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }


  export default class EmployeeDetailComponent extends React.Component<EmployeeDetailComponentProps, EmployeeDetailComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiEndpoint + ApiRoutes.Employees + '/' + this.props.match.params.businessEntityID,
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.EmployeeClientResponseModel;
            
			let mapper = new EmployeeMapper();

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
            return (<EmployeeDetailDisplay history={this.props.history} model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>d058c259f05bec101afbf5ae26a7376f</Hash>
</Codenesium>*/