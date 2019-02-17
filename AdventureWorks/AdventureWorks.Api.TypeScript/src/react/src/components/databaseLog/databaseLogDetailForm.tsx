import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects'
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import DatabaseLogMapper from './databaseLogMapper';
import DatabaseLogViewModel from './databaseLogViewModel';

interface Props {
	history:any;
    model?:DatabaseLogViewModel
}

const DatabaseLogDetailDisplay = (model:Props) => {

   return (
          <form  role="form">
				<button
                  className="btn btn-primary btn-sm align-middle float-right vertically-center"
                  onClick={(e) => { model.history.push(ClientRoutes.DatabaseLogs + '/edit/' + model.model!.databaseLogID)}}
                >
                  <i className="fas fa-edit" />
                </button>
			 						 <div className="form-group row">
							<label htmlFor="databaseLogID" className={"col-sm-2 col-form-label"}>DatabaseLogID</label>
							<div className="col-sm-12">
								{String(model.model!.databaseLogID)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="databaseUser" className={"col-sm-2 col-form-label"}>DatabaseUser</label>
							<div className="col-sm-12">
								{String(model.model!.databaseUser)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="postTime" className={"col-sm-2 col-form-label"}>PostTime</label>
							<div className="col-sm-12">
								{String(model.model!.postTime)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="schema" className={"col-sm-2 col-form-label"}>Schema</label>
							<div className="col-sm-12">
								{String(model.model!.schema)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="tsql" className={"col-sm-2 col-form-label"}>TSQL</label>
							<div className="col-sm-12">
								{String(model.model!.tsql)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="xmlEvent" className={"col-sm-2 col-form-label"}>XmlEvent</label>
							<div className="col-sm-12">
								{String(model.model!.xmlEvent)}
							</div>
						</div>
					             </form>
  );
}

  interface IParams 
  {
     databaseLogID:number;
  }
  
  interface IMatch
  {
     params: IParams;
  }

  interface DatabaseLogDetailComponentProps
  {
     match:IMatch;
	 history:any;
  }

  interface DatabaseLogDetailComponentState
  {
      model?:DatabaseLogViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }


  export default class DatabaseLogDetailComponent extends React.Component<DatabaseLogDetailComponentProps, DatabaseLogDetailComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiEndpoint + ApiRoutes.DatabaseLogs + '/' + this.props.match.params.databaseLogID,
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.DatabaseLogClientResponseModel;
            
			let mapper = new DatabaseLogMapper();

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
            return (<DatabaseLogDetailDisplay history={this.props.history} model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>fdf646096e3f61b3c4b69989693fe746</Hash>
</Codenesium>*/