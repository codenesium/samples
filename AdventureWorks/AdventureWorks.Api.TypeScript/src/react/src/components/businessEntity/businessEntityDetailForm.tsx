import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects'
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import BusinessEntityMapper from './businessEntityMapper';
import BusinessEntityViewModel from './businessEntityViewModel';

interface Props {
	history:any;
    model?:BusinessEntityViewModel
}

const BusinessEntityDetailDisplay = (model:Props) => {

   return (
          <form  role="form">
				<button
                  className="btn btn-primary btn-sm align-middle float-right vertically-center"
                  onClick={(e) => { model.history.push(ClientRoutes.BusinessEntities + '/edit/' + model.model!.businessEntityID)}}
                >
                  <i className="fas fa-edit" />
                </button>
			 						 <div className="form-group row">
							<label htmlFor="businessEntityID" className={"col-sm-2 col-form-label"}>BusinessEntityID</label>
							<div className="col-sm-12">
								{String(model.model!.businessEntityID)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="modifiedDate" className={"col-sm-2 col-form-label"}>ModifiedDate</label>
							<div className="col-sm-12">
								{String(model.model!.modifiedDate)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="rowguid" className={"col-sm-2 col-form-label"}>Rowguid</label>
							<div className="col-sm-12">
								{String(model.model!.rowguid)}
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

  interface BusinessEntityDetailComponentProps
  {
     match:IMatch;
	 history:any;
  }

  interface BusinessEntityDetailComponentState
  {
      model?:BusinessEntityViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }


  export default class BusinessEntityDetailComponent extends React.Component<BusinessEntityDetailComponentProps, BusinessEntityDetailComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiEndpoint + ApiRoutes.BusinessEntities + '/' + this.props.match.params.businessEntityID,
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.BusinessEntityClientResponseModel;
            
			let mapper = new BusinessEntityMapper();

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
            return (<BusinessEntityDetailDisplay history={this.props.history} model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>92b85e62faf89bbf823e22651b0f9a56</Hash>
</Codenesium>*/