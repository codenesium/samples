import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects'
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import SaleMapper from './saleMapper';
import SaleViewModel from './saleViewModel';

interface Props {
	history:any;
    model?:SaleViewModel
}

const SaleDetailDisplay = (model:Props) => {

   return (
          <form  role="form">
				<button
                  className="btn btn-primary btn-sm align-middle float-right vertically-center"
                  onClick={(e) => { model.history.push(ClientRoutes.Sales + '/edit/' + model.model!.id)}}
                >
                  <i className="fas fa-edit" />
                </button>
			 						 <div className="form-group row">
							<label htmlFor="id" className={"col-sm-2 col-form-label"}>Id</label>
							<div className="col-sm-12">
								{String(model.model!.id)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="ipAddress" className={"col-sm-2 col-form-label"}>IpAddress</label>
							<div className="col-sm-12">
								{String(model.model!.ipAddress)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="note" className={"col-sm-2 col-form-label"}>Notes</label>
							<div className="col-sm-12">
								{String(model.model!.note)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="saleDate" className={"col-sm-2 col-form-label"}>SaleDate</label>
							<div className="col-sm-12">
								{String(model.model!.saleDate)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="transactionId" className={"col-sm-2 col-form-label"}>TransactionId</label>
							<div className="col-sm-12">
								{model.model!.transactionIdNavigation!.toDisplay()}
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

  interface SaleDetailComponentProps
  {
     match:IMatch;
	 history:any;
  }

  interface SaleDetailComponentState
  {
      model?:SaleViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }


  export default class SaleDetailComponent extends React.Component<SaleDetailComponentProps, SaleDetailComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiEndpoint + ApiRoutes.Sales + '/' + this.props.match.params.id,
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.SaleClientResponseModel;
            
			let mapper = new SaleMapper();

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
            return (<SaleDetailDisplay history={this.props.history} model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>752678397f466caa45d703e3d7ddeadc</Hash>
</Codenesium>*/