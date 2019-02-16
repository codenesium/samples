import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects'
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import LinkLogMapper from './linkLogMapper';
import LinkLogViewModel from './linkLogViewModel';

interface Props {
	history:any;
    model?:LinkLogViewModel
}

const LinkLogDetailDisplay = (model:Props) => {

   return (
          <form  role="form">
				<button
                  className="btn btn-primary btn-sm align-middle float-right vertically-center"
                  onClick={(e) => { model.history.push(ClientRoutes.LinkLogs + '/edit/' + model.model!.id)}}
                >
                  <i className="fas fa-edit" />
                </button>
			 						 <div className="form-group row">
							<label htmlFor="dateEntered" className={"col-sm-2 col-form-label"}>DateEntered</label>
							<div className="col-sm-12">
								{String(model.model!.dateEntered)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="id" className={"col-sm-2 col-form-label"}>Id</label>
							<div className="col-sm-12">
								{String(model.model!.id)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="linkId" className={"col-sm-2 col-form-label"}>LinkId</label>
							<div className="col-sm-12">
								{model.model!.linkIdNavigation!.toDisplay()}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="log" className={"col-sm-2 col-form-label"}>Log</label>
							<div className="col-sm-12">
								{String(model.model!.log)}
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

  interface LinkLogDetailComponentProps
  {
     match:IMatch;
	 history:any;
  }

  interface LinkLogDetailComponentState
  {
      model?:LinkLogViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }


  export default class LinkLogDetailComponent extends React.Component<LinkLogDetailComponentProps, LinkLogDetailComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiEndpoint + ApiRoutes.LinkLogs + '/' + this.props.match.params.id,
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.LinkLogClientResponseModel;
            
			let mapper = new LinkLogMapper();

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
            return (<LinkLogDetailDisplay history={this.props.history} model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>f806e0e1c88e4ab0fa640d30d201fd29</Hash>
</Codenesium>*/