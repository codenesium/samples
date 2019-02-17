import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects'
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import VenueMapper from './venueMapper';
import VenueViewModel from './venueViewModel';

interface Props {
	history:any;
    model?:VenueViewModel
}

const VenueDetailDisplay = (model:Props) => {

   return (
          <form  role="form">
				<button
                  className="btn btn-primary btn-sm align-middle float-right vertically-center"
                  onClick={(e) => { model.history.push(ClientRoutes.Venues + '/edit/' + model.model!.id)}}
                >
                  <i className="fas fa-edit" />
                </button>
			 						 <div className="form-group row">
							<label htmlFor="address1" className={"col-sm-2 col-form-label"}>Address1</label>
							<div className="col-sm-12">
								{String(model.model!.address1)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="address2" className={"col-sm-2 col-form-label"}>Address2</label>
							<div className="col-sm-12">
								{String(model.model!.address2)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="adminId" className={"col-sm-2 col-form-label"}>AdminId</label>
							<div className="col-sm-12">
								{model.model!.adminIdNavigation!.toDisplay()}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="email" className={"col-sm-2 col-form-label"}>Email</label>
							<div className="col-sm-12">
								{String(model.model!.email)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="facebook" className={"col-sm-2 col-form-label"}>Facebook</label>
							<div className="col-sm-12">
								{String(model.model!.facebook)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="name" className={"col-sm-2 col-form-label"}>Name</label>
							<div className="col-sm-12">
								{String(model.model!.name)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="phone" className={"col-sm-2 col-form-label"}>Phone</label>
							<div className="col-sm-12">
								{String(model.model!.phone)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="provinceId" className={"col-sm-2 col-form-label"}>ProvinceId</label>
							<div className="col-sm-12">
								{model.model!.provinceIdNavigation!.toDisplay()}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="website" className={"col-sm-2 col-form-label"}>Website</label>
							<div className="col-sm-12">
								{String(model.model!.website)}
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

  interface VenueDetailComponentProps
  {
     match:IMatch;
	 history:any;
  }

  interface VenueDetailComponentState
  {
      model?:VenueViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }


  export default class VenueDetailComponent extends React.Component<VenueDetailComponentProps, VenueDetailComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiEndpoint + ApiRoutes.Venues + '/' + this.props.match.params.id,
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.VenueClientResponseModel;
            
			let mapper = new VenueMapper();

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
            return (<VenueDetailDisplay history={this.props.history} model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>104c2721dcc702babab55684f23b47b2</Hash>
</Codenesium>*/