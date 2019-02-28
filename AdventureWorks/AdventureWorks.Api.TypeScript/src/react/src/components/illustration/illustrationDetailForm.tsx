import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import IllustrationMapper from './illustrationMapper';
import IllustrationViewModel from './illustrationViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import {ProductModelIllustrationTableComponent} from '../shared/productModelIllustrationTable'
	



interface IllustrationDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface IllustrationDetailComponentState {
  model?: IllustrationViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class IllustrationDetailComponent extends React.Component<
IllustrationDetailComponentProps,
IllustrationDetailComponentState
> {
  state = {
    model: new IllustrationViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: ''
  };

  handleEditClick(e:any) {
    this.props.history.push(ClientRoutes.Illustrations + '/edit/' + this.state.model!.illustrationID);
  }
  
  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Illustrations +
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
          let response = resp.data as Api.IllustrationClientResponseModel;

          console.log(response);

          let mapper = new IllustrationMapper();

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
							<h3>Diagram</h3>
							<p>{String(this.state.model!.diagram)}</p>
						 </div>
					   						 <div>
							<h3>IllustrationID</h3>
							<p>{String(this.state.model!.illustrationID)}</p>
						 </div>
					   						 <div>
							<h3>ModifiedDate</h3>
							<p>{String(this.state.model!.modifiedDate)}</p>
						 </div>
					   		  </div>
          {message}
		 <div>
            <h3>ProductModelIllustrations</h3>
            <ProductModelIllustrationTableComponent 
			productModelID={this.state.model!.productModelID} 
			history={this.props.history} 
			match={this.props.match} 
			apiRoute={Constants.ApiEndpoint + ApiRoutes.Illustrations + '/' + this.state.model!.illustrationID + '/' + ApiRoutes.ProductModelIllustrations}
			/>
         </div>
	

        </div>
      );
    } else {
      return null;
    }
  }
}

export const WrappedIllustrationDetailComponent = Form.create({ name: 'Illustration Detail' })(
  IllustrationDetailComponent
);

/*<Codenesium>
    <Hash>d02c16a2b7eae38779156e0f25bab7a0</Hash>
</Codenesium>*/