import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects'
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import SalesReasonMapper from './salesReasonMapper';
import SalesReasonViewModel from './salesReasonViewModel';

interface Props {
	history:any;
    model?:SalesReasonViewModel
}

const SalesReasonDetailDisplay = (model:Props) => {

   return (
          <form  role="form">
				<button
                  className="btn btn-primary btn-sm align-middle float-right vertically-center"
                  onClick={(e) => { model.history.push(ClientRoutes.SalesReasons + '/edit/' + model.model!.salesReasonID)}}
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
							<label htmlFor="reasonType" className={"col-sm-2 col-form-label"}>ReasonType</label>
							<div className="col-sm-12">
								{String(model.model!.reasonType)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="salesReasonID" className={"col-sm-2 col-form-label"}>SalesReasonID</label>
							<div className="col-sm-12">
								{String(model.model!.salesReasonID)}
							</div>
						</div>
					             </form>
  );
}

  interface IParams 
  {
     salesReasonID:number;
  }
  
  interface IMatch
  {
     params: IParams;
  }

  interface SalesReasonDetailComponentProps
  {
     match:IMatch;
	 history:any;
  }

  interface SalesReasonDetailComponentState
  {
      model?:SalesReasonViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }


  export default class SalesReasonDetailComponent extends React.Component<SalesReasonDetailComponentProps, SalesReasonDetailComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiEndpoint + ApiRoutes.SalesReasons + '/' + this.props.match.params.salesReasonID,
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.SalesReasonClientResponseModel;
            
			let mapper = new SalesReasonMapper();

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
            return (<SalesReasonDetailDisplay history={this.props.history} model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>5bbfc616f41194eda073a174b0d29023</Hash>
</Codenesium>*/