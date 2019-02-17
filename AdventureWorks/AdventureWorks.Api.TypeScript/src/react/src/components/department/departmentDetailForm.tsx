import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects'
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import DepartmentMapper from './departmentMapper';
import DepartmentViewModel from './departmentViewModel';

interface Props {
	history:any;
    model?:DepartmentViewModel
}

const DepartmentDetailDisplay = (model:Props) => {

   return (
          <form  role="form">
				<button
                  className="btn btn-primary btn-sm align-middle float-right vertically-center"
                  onClick={(e) => { model.history.push(ClientRoutes.Departments + '/edit/' + model.model!.departmentID)}}
                >
                  <i className="fas fa-edit" />
                </button>
			 						 <div className="form-group row">
							<label htmlFor="departmentID" className={"col-sm-2 col-form-label"}>DepartmentID</label>
							<div className="col-sm-12">
								{String(model.model!.departmentID)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="groupName" className={"col-sm-2 col-form-label"}>GroupName</label>
							<div className="col-sm-12">
								{String(model.model!.groupName)}
							</div>
						</div>
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
					             </form>
  );
}

  interface IParams 
  {
     departmentID:number;
  }
  
  interface IMatch
  {
     params: IParams;
  }

  interface DepartmentDetailComponentProps
  {
     match:IMatch;
	 history:any;
  }

  interface DepartmentDetailComponentState
  {
      model?:DepartmentViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }


  export default class DepartmentDetailComponent extends React.Component<DepartmentDetailComponentProps, DepartmentDetailComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiEndpoint + ApiRoutes.Departments + '/' + this.props.match.params.departmentID,
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.DepartmentClientResponseModel;
            
			let mapper = new DepartmentMapper();

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
            return (<DepartmentDetailDisplay history={this.props.history} model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>ddfefad1a10fc4a8b4ef2a22415585c2</Hash>
</Codenesium>*/