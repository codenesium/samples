import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects'
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import SpaceFeatureMapper from './spaceFeatureMapper';
import SpaceFeatureViewModel from './spaceFeatureViewModel';

interface Props {
	history:any;
    model?:SpaceFeatureViewModel
}

const SpaceFeatureDetailDisplay = (model:Props) => {

   return (
          <form  role="form">
				<button
                  className="btn btn-primary btn-sm align-middle float-right vertically-center"
                  onClick={(e) => { model.history.push(ClientRoutes.SpaceFeatures + '/edit/' + model.model!.id)}}
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
     id:number;
  }
  
  interface IMatch
  {
     params: IParams;
  }

  interface SpaceFeatureDetailComponentProps
  {
     match:IMatch;
	 history:any;
  }

  interface SpaceFeatureDetailComponentState
  {
      model?:SpaceFeatureViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }


  export default class SpaceFeatureDetailComponent extends React.Component<SpaceFeatureDetailComponentProps, SpaceFeatureDetailComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiEndpoint + ApiRoutes.SpaceFeatures + '/' + this.props.match.params.id,
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.SpaceFeatureClientResponseModel;
            
			let mapper = new SpaceFeatureMapper();

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
            return (<SpaceFeatureDetailDisplay history={this.props.history} model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>f4f0d5a212bef7827226d9e19ae41753</Hash>
</Codenesium>*/