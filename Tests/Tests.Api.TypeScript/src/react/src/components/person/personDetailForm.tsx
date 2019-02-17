import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects'
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import PersonMapper from './personMapper';
import PersonViewModel from './personViewModel';

interface Props {
	history:any;
    model?:PersonViewModel
}

const PersonDetailDisplay = (model:Props) => {

   return (
          <form  role="form">
				<button
                  className="btn btn-primary btn-sm align-middle float-right vertically-center"
                  onClick={(e) => { model.history.push(ClientRoutes.People + '/edit/' + model.model!.personId)}}
                >
                  <i className="fas fa-edit" />
                </button>
			 						 <div className="form-group row">
							<label htmlFor="personId" className={"col-sm-2 col-form-label"}>PersonId</label>
							<div className="col-sm-12">
								{String(model.model!.personId)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="personName" className={"col-sm-2 col-form-label"}>PersonName</label>
							<div className="col-sm-12">
								{String(model.model!.personName)}
							</div>
						</div>
					             </form>
  );
}

  interface IParams 
  {
     personId:number;
  }
  
  interface IMatch
  {
     params: IParams;
  }

  interface PersonDetailComponentProps
  {
     match:IMatch;
	 history:any;
  }

  interface PersonDetailComponentState
  {
      model?:PersonViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }


  export default class PersonDetailComponent extends React.Component<PersonDetailComponentProps, PersonDetailComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiEndpoint + ApiRoutes.People + '/' + this.props.match.params.personId,
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.PersonClientResponseModel;
            
			let mapper = new PersonMapper();

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
            return (<PersonDetailDisplay history={this.props.history} model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>f54e8743edfaf6742af336b7c7e68c14</Hash>
</Codenesium>*/