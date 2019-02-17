import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects'
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import CultureMapper from './cultureMapper';
import CultureViewModel from './cultureViewModel';

interface Props {
	history:any;
    model?:CultureViewModel
}

const CultureDetailDisplay = (model:Props) => {

   return (
          <form  role="form">
				<button
                  className="btn btn-primary btn-sm align-middle float-right vertically-center"
                  onClick={(e) => { model.history.push(ClientRoutes.Cultures + '/edit/' + model.model!.cultureID)}}
                >
                  <i className="fas fa-edit" />
                </button>
			 						 <div className="form-group row">
							<label htmlFor="cultureID" className={"col-sm-2 col-form-label"}>CultureID</label>
							<div className="col-sm-12">
								{String(model.model!.cultureID)}
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
     cultureID:string;
  }
  
  interface IMatch
  {
     params: IParams;
  }

  interface CultureDetailComponentProps
  {
     match:IMatch;
	 history:any;
  }

  interface CultureDetailComponentState
  {
      model?:CultureViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }


  export default class CultureDetailComponent extends React.Component<CultureDetailComponentProps, CultureDetailComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiEndpoint + ApiRoutes.Cultures + '/' + this.props.match.params.cultureID,
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.CultureClientResponseModel;
            
			let mapper = new CultureMapper();

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
            return (<CultureDetailDisplay history={this.props.history} model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>30c89be84d2b56de82d645fb6df96cbd</Hash>
</Codenesium>*/