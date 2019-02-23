import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import RateMapper from './rateMapper';
import RateViewModel from './rateViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';




interface RateDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface RateDetailComponentState {
  model?: RateViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class RateDetailComponent extends React.Component<
RateDetailComponentProps,
RateDetailComponentState
> {
  state = {
    model: new RateViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: ''
  };

  handleEditClick(e:any) {
    this.props.history.push(ClientRoutes.Rates + '/edit/' + this.state.model!.id);
  }
  
  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Rates +
          '/' +
          this.props.match.params.id,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.RateClientResponseModel;

          console.log(response);

          let mapper = new RateMapper();

          this.setState({
            model: mapper.mapApiResponseToViewModel(response),
            loading: false,
            loaded: true,
            errorOccurred: false,
            errorMessage: '',
          });
        },
        error => {
          console.log(error);
          this.setState({
            model: undefined,
            loading: false,
            loaded: true,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
  }

  render() {
    
    let message: JSX.Element = <div />;
    if (this.state.errorOccurred) {
      message = <Alert message={this.state.errorMessage} type="error" />;
    } 
  
    if (this.state.loading) {
      return <Spin size="large" />;
    } else if (this.state.loaded) {
      return (
        <div>
		<Button 
			style={{'float':'right'}}
			type="primary" 
			onClick={(e:any) => {
				this.handleEditClick(e)
				}}
			>
             <i className="fas fa-edit" />
		  </Button>
		  <div>
									 <div>
							<h3>amountPerMinute</h3>
							<p>{String(this.state.model!.amountPerMinute)}</p>
						 </div>
					   						 <div>
							<h3>id</h3>
							<p>{String(this.state.model!.id)}</p>
						 </div>
					   						 <div>
							<h3>teacherId</h3>
							<p>{String(this.state.model!.teacherId)}</p>
						 </div>
					   						 <div>
							<h3>teacherSkillId</h3>
							<p>{String(this.state.model!.teacherSkillId)}</p>
						 </div>
					   		  </div>
          {message}


        </div>
      );
    } else {
      return null;
    }
  }
}

export const WrappedRateDetailComponent = Form.create({ name: 'Rate Detail' })(
  RateDetailComponent
);

/*<Codenesium>
    <Hash>03685e4964e16be97a77c27061724a0a</Hash>
</Codenesium>*/