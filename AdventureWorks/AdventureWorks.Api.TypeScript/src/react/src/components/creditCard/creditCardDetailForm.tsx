import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects'
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import CreditCardMapper from './creditCardMapper';
import CreditCardViewModel from './creditCardViewModel';

interface Props {
	history:any;
    model?:CreditCardViewModel
}

const CreditCardDetailDisplay = (model:Props) => {

   return (
          <form  role="form">
				<button
                  className="btn btn-primary btn-sm align-middle float-right vertically-center"
                  onClick={(e) => { model.history.push(ClientRoutes.CreditCards + '/edit/' + model.model!.creditCardID)}}
                >
                  <i className="fas fa-edit" />
                </button>
			 						 <div className="form-group row">
							<label htmlFor="cardNumber" className={"col-sm-2 col-form-label"}>CardNumber</label>
							<div className="col-sm-12">
								{String(model.model!.cardNumber)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="cardType" className={"col-sm-2 col-form-label"}>CardType</label>
							<div className="col-sm-12">
								{String(model.model!.cardType)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="creditCardID" className={"col-sm-2 col-form-label"}>CreditCardID</label>
							<div className="col-sm-12">
								{String(model.model!.creditCardID)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="expMonth" className={"col-sm-2 col-form-label"}>ExpMonth</label>
							<div className="col-sm-12">
								{String(model.model!.expMonth)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="expYear" className={"col-sm-2 col-form-label"}>ExpYear</label>
							<div className="col-sm-12">
								{String(model.model!.expYear)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="modifiedDate" className={"col-sm-2 col-form-label"}>ModifiedDate</label>
							<div className="col-sm-12">
								{String(model.model!.modifiedDate)}
							</div>
						</div>
					             </form>
  );
}

  interface IParams 
  {
     creditCardID:number;
  }
  
  interface IMatch
  {
     params: IParams;
  }

  interface CreditCardDetailComponentProps
  {
     match:IMatch;
	 history:any;
  }

  interface CreditCardDetailComponentState
  {
      model?:CreditCardViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }


  export default class CreditCardDetailComponent extends React.Component<CreditCardDetailComponentProps, CreditCardDetailComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiEndpoint + ApiRoutes.CreditCards + '/' + this.props.match.params.creditCardID,
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.CreditCardClientResponseModel;
            
			let mapper = new CreditCardMapper();

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
            return (<CreditCardDetailDisplay history={this.props.history} model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>b0f2cb219a56b154ba3697c395c8f05b</Hash>
</Codenesium>*/