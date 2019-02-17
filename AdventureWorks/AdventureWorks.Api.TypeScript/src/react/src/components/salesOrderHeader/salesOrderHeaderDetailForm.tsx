import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects'
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import SalesOrderHeaderMapper from './salesOrderHeaderMapper';
import SalesOrderHeaderViewModel from './salesOrderHeaderViewModel';

interface Props {
	history:any;
    model?:SalesOrderHeaderViewModel
}

const SalesOrderHeaderDetailDisplay = (model:Props) => {

   return (
          <form  role="form">
				<button
                  className="btn btn-primary btn-sm align-middle float-right vertically-center"
                  onClick={(e) => { model.history.push(ClientRoutes.SalesOrderHeaders + '/edit/' + model.model!.salesOrderID)}}
                >
                  <i className="fas fa-edit" />
                </button>
			 						 <div className="form-group row">
							<label htmlFor="accountNumber" className={"col-sm-2 col-form-label"}>AccountNumber</label>
							<div className="col-sm-12">
								{String(model.model!.accountNumber)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="billToAddressID" className={"col-sm-2 col-form-label"}>BillToAddressID</label>
							<div className="col-sm-12">
								{String(model.model!.billToAddressID)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="comment" className={"col-sm-2 col-form-label"}>Comment</label>
							<div className="col-sm-12">
								{String(model.model!.comment)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="creditCardApprovalCode" className={"col-sm-2 col-form-label"}>CreditCardApprovalCode</label>
							<div className="col-sm-12">
								{String(model.model!.creditCardApprovalCode)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="creditCardID" className={"col-sm-2 col-form-label"}>CreditCardID</label>
							<div className="col-sm-12">
								{model.model!.creditCardIDNavigation!.toDisplay()}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="currencyRateID" className={"col-sm-2 col-form-label"}>CurrencyRateID</label>
							<div className="col-sm-12">
								{model.model!.currencyRateIDNavigation!.toDisplay()}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="customerID" className={"col-sm-2 col-form-label"}>CustomerID</label>
							<div className="col-sm-12">
								{model.model!.customerIDNavigation!.toDisplay()}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="dueDate" className={"col-sm-2 col-form-label"}>DueDate</label>
							<div className="col-sm-12">
								{String(model.model!.dueDate)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="freight" className={"col-sm-2 col-form-label"}>Freight</label>
							<div className="col-sm-12">
								{String(model.model!.freight)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="modifiedDate" className={"col-sm-2 col-form-label"}>ModifiedDate</label>
							<div className="col-sm-12">
								{String(model.model!.modifiedDate)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="onlineOrderFlag" className={"col-sm-2 col-form-label"}>OnlineOrderFlag</label>
							<div className="col-sm-12">
								{String(model.model!.onlineOrderFlag)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="orderDate" className={"col-sm-2 col-form-label"}>OrderDate</label>
							<div className="col-sm-12">
								{String(model.model!.orderDate)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="purchaseOrderNumber" className={"col-sm-2 col-form-label"}>PurchaseOrderNumber</label>
							<div className="col-sm-12">
								{String(model.model!.purchaseOrderNumber)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="revisionNumber" className={"col-sm-2 col-form-label"}>RevisionNumber</label>
							<div className="col-sm-12">
								{String(model.model!.revisionNumber)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="rowguid" className={"col-sm-2 col-form-label"}>Rowguid</label>
							<div className="col-sm-12">
								{String(model.model!.rowguid)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="salesOrderID" className={"col-sm-2 col-form-label"}>SalesOrderID</label>
							<div className="col-sm-12">
								{String(model.model!.salesOrderID)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="salesOrderNumber" className={"col-sm-2 col-form-label"}>SalesOrderNumber</label>
							<div className="col-sm-12">
								{String(model.model!.salesOrderNumber)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="salesPersonID" className={"col-sm-2 col-form-label"}>SalesPersonID</label>
							<div className="col-sm-12">
								{model.model!.salesPersonIDNavigation!.toDisplay()}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="shipDate" className={"col-sm-2 col-form-label"}>ShipDate</label>
							<div className="col-sm-12">
								{String(model.model!.shipDate)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="shipMethodID" className={"col-sm-2 col-form-label"}>ShipMethodID</label>
							<div className="col-sm-12">
								{String(model.model!.shipMethodID)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="shipToAddressID" className={"col-sm-2 col-form-label"}>ShipToAddressID</label>
							<div className="col-sm-12">
								{String(model.model!.shipToAddressID)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="status" className={"col-sm-2 col-form-label"}>Status</label>
							<div className="col-sm-12">
								{String(model.model!.status)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="subTotal" className={"col-sm-2 col-form-label"}>SubTotal</label>
							<div className="col-sm-12">
								{String(model.model!.subTotal)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="taxAmt" className={"col-sm-2 col-form-label"}>TaxAmt</label>
							<div className="col-sm-12">
								{String(model.model!.taxAmt)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="territoryID" className={"col-sm-2 col-form-label"}>TerritoryID</label>
							<div className="col-sm-12">
								{model.model!.territoryIDNavigation!.toDisplay()}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="totalDue" className={"col-sm-2 col-form-label"}>TotalDue</label>
							<div className="col-sm-12">
								{String(model.model!.totalDue)}
							</div>
						</div>
					             </form>
  );
}

  interface IParams 
  {
     salesOrderID:number;
  }
  
  interface IMatch
  {
     params: IParams;
  }

  interface SalesOrderHeaderDetailComponentProps
  {
     match:IMatch;
	 history:any;
  }

  interface SalesOrderHeaderDetailComponentState
  {
      model?:SalesOrderHeaderViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }


  export default class SalesOrderHeaderDetailComponent extends React.Component<SalesOrderHeaderDetailComponentProps, SalesOrderHeaderDetailComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiEndpoint + ApiRoutes.SalesOrderHeaders + '/' + this.props.match.params.salesOrderID,
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.SalesOrderHeaderClientResponseModel;
            
			let mapper = new SalesOrderHeaderMapper();

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
            return (<SalesOrderHeaderDetailDisplay history={this.props.history} model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>82acd2a51181ed686bbe32b5e5e0850f</Hash>
</Codenesium>*/