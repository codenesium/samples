import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects'
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import IllustrationMapper from './illustrationMapper';
import IllustrationViewModel from './illustrationViewModel';

interface Props {
	history:any;
    model?:IllustrationViewModel
}

const IllustrationDetailDisplay = (model:Props) => {

   return (
          <form  role="form">
				<button
                  className="btn btn-primary btn-sm align-middle float-right vertically-center"
                  onClick={(e) => { model.history.push(ClientRoutes.Illustrations + '/edit/' + model.model!.illustrationID)}}
                >
                  <i className="fas fa-edit" />
                </button>
			 						 <div className="form-group row">
							<label htmlFor="diagram" className={"col-sm-2 col-form-label"}>Diagram</label>
							<div className="col-sm-12">
								{String(model.model!.diagram)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="illustrationID" className={"col-sm-2 col-form-label"}>IllustrationID</label>
							<div className="col-sm-12">
								{String(model.model!.illustrationID)}
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
     illustrationID:number;
  }
  
  interface IMatch
  {
     params: IParams;
  }

  interface IllustrationDetailComponentProps
  {
     match:IMatch;
	 history:any;
  }

  interface IllustrationDetailComponentState
  {
      model?:IllustrationViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }


  export default class IllustrationDetailComponent extends React.Component<IllustrationDetailComponentProps, IllustrationDetailComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiEndpoint + ApiRoutes.Illustrations + '/' + this.props.match.params.illustrationID,
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.IllustrationClientResponseModel;
            
			let mapper = new IllustrationMapper();

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
            return (<IllustrationDetailDisplay history={this.props.history} model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>724561eeb8c96c7d9fcc248b6b16efdc</Hash>
</Codenesium>*/