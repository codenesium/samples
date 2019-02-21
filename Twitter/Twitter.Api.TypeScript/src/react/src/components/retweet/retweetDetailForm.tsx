import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects'
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import RetweetMapper from './retweetMapper';
import RetweetViewModel from './retweetViewModel';

interface Props {
	history:any;
    model?:RetweetViewModel
}

const RetweetDetailDisplay = (model:Props) => {

   return (
          <form  role="form">
				<button
                  className="btn btn-primary btn-sm align-middle float-right vertically-center"
                  onClick={(e) => { model.history.push(ClientRoutes.Retweets + '/edit/' + model.model!.id)}}
                >
                  <i className="fas fa-edit" />
                </button>
			 						 <div className="form-group row">
							<label htmlFor="date" className={"col-sm-2 col-form-label"}>Date</label>
							<div className="col-sm-12">
								{String(model.model!.date)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="retwitterUserId" className={"col-sm-2 col-form-label"}>Retwitter_user_id</label>
							<div className="col-sm-12">
								{model.model!.retwitterUserIdNavigation!.toDisplay()}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="time" className={"col-sm-2 col-form-label"}>Time</label>
							<div className="col-sm-12">
								{String(model.model!.time)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="tweetTweetId" className={"col-sm-2 col-form-label"}>Tweet_tweet_id</label>
							<div className="col-sm-12">
								{model.model!.tweetTweetIdNavigation!.toDisplay()}
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

  interface RetweetDetailComponentProps
  {
     match:IMatch;
	 history:any;
  }

  interface RetweetDetailComponentState
  {
      model?:RetweetViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }


  export default class RetweetDetailComponent extends React.Component<RetweetDetailComponentProps, RetweetDetailComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiEndpoint + ApiRoutes.Retweets + '/' + this.props.match.params.id,
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.RetweetClientResponseModel;
            
			let mapper = new RetweetMapper();

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
            return (<RetweetDetailDisplay history={this.props.history} model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>9ee5a8af3d90e46dd43c0e90e88556b3</Hash>
</Codenesium>*/