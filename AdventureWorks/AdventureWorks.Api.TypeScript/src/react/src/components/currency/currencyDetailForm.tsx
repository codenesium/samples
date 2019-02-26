import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import CurrencyMapper from './currencyMapper';
import CurrencyViewModel from './currencyViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import {CountryRegionCurrencyTableComponent} from '../shared/countryRegionCurrencyTable'
	import {CurrencyRateTableComponent} from '../shared/currencyRateTable'
	



interface CurrencyDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface CurrencyDetailComponentState {
  model?: CurrencyViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class CurrencyDetailComponent extends React.Component<
CurrencyDetailComponentProps,
CurrencyDetailComponentState
> {
  state = {
    model: new CurrencyViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: ''
  };

  handleEditClick(e:any) {
    this.props.history.push(ClientRoutes.Currencies + '/edit/' + this.state.model!.currencyCode);
  }
  
  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Currencies +
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
          let response = resp.data as Api.CurrencyClientResponseModel;

          console.log(response);

          let mapper = new CurrencyMapper();

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
							<h3>CurrencyCode</h3>
							<p>{String(this.state.model!.currencyCode)}</p>
						 </div>
					   						 <div>
							<h3>ModifiedDate</h3>
							<p>{String(this.state.model!.modifiedDate)}</p>
						 </div>
					   						 <div>
							<h3>Name</h3>
							<p>{String(this.state.model!.name)}</p>
						 </div>
					   		  </div>
          {message}
		 <div>
            <h3>CountryRegionCurrencies</h3>
            <CountryRegionCurrencyTableComponent 
			countryRegionCode={this.state.model!.countryRegionCode} 
			history={this.props.history} 
			match={this.props.match} 
			apiRoute={Constants.ApiEndpoint + ApiRoutes.Currencies + '/' + this.state.model!.currencyCode + '/' + ApiRoutes.CountryRegionCurrencies}
			/>
         </div>
			 <div>
            <h3>CurrencyRates</h3>
            <CurrencyRateTableComponent 
			currencyRateID={this.state.model!.currencyRateID} 
			history={this.props.history} 
			match={this.props.match} 
			apiRoute={Constants.ApiEndpoint + ApiRoutes.Currencies + '/' + this.state.model!.currencyCode + '/' + ApiRoutes.CurrencyRates}
			/>
         </div>
	

        </div>
      );
    } else {
      return null;
    }
  }
}

export const WrappedCurrencyDetailComponent = Form.create({ name: 'Currency Detail' })(
  CurrencyDetailComponent
);

/*<Codenesium>
    <Hash>542e36528f310015a76af0d89df4c898</Hash>
</Codenesium>*/